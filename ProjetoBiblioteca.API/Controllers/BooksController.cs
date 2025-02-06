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

    [HttpPut("{id}/Loaned")]
    public IActionResult Loaned(int id)
    {
        var result = _services.Loaned(id);
        if (!result.IsSucess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }
   
    [HttpPut("{id}/MakesAvailable")]
    public IActionResult MakesAvailable(int id)
    {
        var result = _services.MakesAvailable(id);
        if (!result.IsSucess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
        
        
    }
    [HttpPut("{id}/Reserved")]
    public IActionResult Reserved(int id)
    {
        var result = _services.Reserved(id);
        if (!result.IsSucess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }
    [HttpPut("{id}/MakesUnvailable")]
    public IActionResult MakesUnvailable(int id)
    {
        var result = _services.MakesUnvailable(id);
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
