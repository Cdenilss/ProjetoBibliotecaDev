using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.InputModels;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Enums;
using ProjetoBiblioteca.Infrastructure.Persistence;


namespace ProjetoBiblioteca.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LibaryDbContext _context;

        public LoansController(LibaryDbContext context)
        {
            _context = context;
        }
       
        [HttpGet("{id}")]
        public IActionResult GetLoanById(int id )
        {
            var loans = _context.Loans
                .Include(l => l.User)
                .Include(l=>l.Book)
                .FirstOrDefault(l => l.Id == id);
            if (loans == null)
            {
                return NotFound(); 
            }

            var model = LoanViewModel.FromEntity(loans);
            
            
            return Ok(model);
        }        
        [HttpPost]
        
        public IActionResult PostLoan(CreateLoanInputModel model)
        {

            var book = _context.Books.FirstOrDefault(b => b.Id == model.IdBook);
            if (book==null)
            {
                return NotFound("Livro Nao encontrado ");
            }

            if (book.Status != BookStatusEnum.Available)
            {
                return BadRequest("Livro Não Disponivel");
            }
        
            var loan = model.ToEntity();

            _context.Add(loan);
            _context.SaveChanges();
            
            return CreatedAtAction(nameof(GetLoanById), new { id = loan.Id }, loan);
        }
        
        
    }
}