using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Application.Commands.BookCommands.DeleteBook;
using ProjetoBiblioteca.Application.Commands.BookCommands.InsertBook;
using ProjetoBiblioteca.Application.Queries.BookQueries.GetAllBooks;
using ProjetoBiblioteca.Application.Queries.BookQueries.GetBooksById;


namespace ProjetoBiblioteca.Controllers;
    [Route("api/Books")]
    [ApiController]


public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;


    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]

    public async Task<IActionResult> FindBookById(int id)
    {
        var result = await _mediator.Send(new GetBookByIdQueries(id));
        
        if (!result.IsSucess)
        {
          return BadRequest(result.Message);
        }
        return Ok(result);
        
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {

        //var result = _services.GetAll();
        var query = new GetAllBooksQueries();

        var result = await _mediator.Send(query);
        return Ok(result);
        
    }
    
     
    [HttpPost]
    public async Task<IActionResult> Post(InsertBookCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(FindBookById), new { id = result.Data }, command);
    }

    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteBookCommand(id));
        if (!result.IsSucess)
        {
            return BadRequest(result.Message);
        }
        return NoContent();
    }
    
}
