using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Models;

namespace ProjetoBiblioteca.Controllers{
    [Route("api/Books")]
    [ApiController]


public class BooksController : ControllerBase
{

    [HttpGet ("search")]
    public IActionResult Get(string search)
    {
        return Ok();
    }
    
    [HttpGet("{id}")]

    public IActionResult GetById(int id)
    {
        return Ok();
        
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
    
     
    [HttpPost]
    public IActionResult Post(CreateBooksInputModel model)
    {
        return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
    }

    [HttpPut("{id}")]
    public IActionResult PutBook()
    {
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
}