using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoBiblioteca.Models;
using ProjetoBiblioteca.Models.ViewModel;
using ProjetoBiblioteca.Persistence;

namespace ProjetoBiblioteca.Controllers
{
    
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LibaryDbContext _context;

        public UsersController(LibaryDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult FindUserById(int id)
        {
            var user = _context.Users
                .Include(u => u.LoansList)
                .ThenInclude(l => l.Book) 
                .SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound(); 
            }

            var model = UserViewModel.FromEntity(user);
            
            return Ok(model);
        }        
        
        [HttpPost]
        public IActionResult PostUser(CreateUserInputModel model)
        {
            var user = model.ToEntity();
            _context.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(FindUserById), new { id = user.Id }, model);
            
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateUserInputModel model)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            user.Update(model.Nome, model.Email);
            _context.Users.Update(user);
            _context.SaveChanges();
            
            return Ok();
        }
        [HttpPut("{id}/profile-picture")]
        public IActionResult PutProfilePicture(IFormFile file)
        {
            var description = $"File : {file.FileName}, Tamanho: {file.Length}";
            return Ok(description);
        }
        [HttpDelete("{id}")]
        public IActionResult Delate(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            user.SetAsDeleted();
            _context.Users.Update(user);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
    
   
}