using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Models;

namespace ProjetoBiblioteca.Controllers{
    [Route("api/Books")]
    [ApiController]


public class BooksController : ControllerBase
{
    // GET api/books/search
    [HttpGet ("search")]
    public IActionResult Get(string search)
    {
        return Ok();
    }
    // GET api/books/1
    [HttpGet("{id}")]

    public IActionResult GetById(int id)
    {
        return Ok();
        
    }
    // GET api/All-books
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
    
    //POST api/books
    [HttpPost]
    public IActionResult Post(CreateBooksInputModel model)
    {
        return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
    }
    
    //DELATE api/books/{1}

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
}