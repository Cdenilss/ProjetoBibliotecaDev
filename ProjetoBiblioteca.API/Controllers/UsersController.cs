using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoBiblioteca.Application.Models.InputModels;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Application.Services;
using ProjetoBiblioteca.Infrastructure.Persistence;



namespace ProjetoBiblioteca.Controllers
{
    
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LibraryDbContext _context;
        private readonly IUserService _services;

        public UsersController(LibraryDbContext context, IUserService services)
        {
            _context = context;
            _services = services;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _services.GetAll();
            
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult FindUserById(int id)
        {
            var result = _services.FindUserById(id);
            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
            
        }        
        
        
        [HttpPost]
        public IActionResult PostUser(CreateUserInputModel model)
        {
            var result = _services.Insert(model);
            return CreatedAtAction(nameof(FindUserById), new { id = result.Data}, model);
            
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateUserInputModel model)
        {
            var result = _services.Put(id,model);
            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
            
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _services.Delete(id);
            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
            return NoContent();
        }
    }
    
   
}