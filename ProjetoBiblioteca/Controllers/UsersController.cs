using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Models;

namespace ProjetoBiblioteca.Controllers
{
    
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            return Ok();
        }        
        
        [HttpPost]
        public IActionResult PostUser(CreateUserInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
            
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(IFormFile file)
        {
            var description = $"File : {file.FileName}, Tamanho: {file.Length}";
            return Ok(description);
        }
    }
}