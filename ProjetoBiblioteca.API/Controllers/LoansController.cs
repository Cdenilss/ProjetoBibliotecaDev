using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Application.Models.InputModels;
using ProjetoBiblioteca.Application.Services;
using ProjetoBiblioteca.Infrastructure.Persistence;


namespace ProjetoBiblioteca.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LibraryDbContext _context;
        private readonly ILoanService _services;

        public LoansController(LibraryDbContext context, ILoanService services)
        {
            _context = context;
            _services = services;
        }
       
        [HttpGet("{id}")]
        public IActionResult GetLoanById(int id )
        {
            var result = _services.GetLoanById(id);
            if (!result.IsSucess)
            {
                return NotFound(result.Message); 
            }

            return Ok(result); 
            
        }        
        [HttpPost]
        
        public IActionResult PostLoan(CreateLoanInputModel model)
        {
            var result = _services.Insert(model);
            return CreatedAtAction(nameof(GetLoanById), new { id = result.Data }, model);
        }
        
        
    }
}