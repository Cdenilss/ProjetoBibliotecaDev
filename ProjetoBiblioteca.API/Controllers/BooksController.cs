using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Application.Models.InputModels;
using ProjetoBiblioteca.Application.Services;


namespace ProjetoBiblioteca.Controllers;
    [Route("api/Books")]
    [ApiController]


public class BooksController : ControllerBase
{
    private readonly IBookServices _services;


    public BooksController(IBookServices services)
    {
        _services = services;
    }
    
    [HttpGet("{id}")]

    public IActionResult FindBookById(int id)
    {
        var result = _services.FindById(id);
        if (!result.IsSucess)
        {
          return BadRequest(result.Message);
        }
        return Ok(result);
        
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {

        var result = _services.GetAll();
        return Ok(result);
        
    }
    
     
    [HttpPost]
    public IActionResult Post(CreateBooksInputModel model)
    {
        var result = _services.Insert(model);
        return CreatedAtAction(nameof(FindBookById), new { id = result.Data }, model);
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
