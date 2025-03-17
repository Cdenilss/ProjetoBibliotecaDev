using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Application.Commands.BookCommands.DeleteBook;
using ProjetoBiblioteca.Application.Commands.BookCommands.InsertBook;
using ProjetoBiblioteca.Application.Queries.BookQueries.GetAllBooks;
using ProjetoBiblioteca.Application.Queries.BookQueries.GetBooksById;
using ProjetoBiblioteca.Core.Enums;


namespace ProjetoBiblioteca.Controllers;
    [Route("api/Books")]
    [ApiController]
    [Authorize]


public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;


    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> FindBookById(int id)
    {
        var result = await _mediator.Send(new GetBookByIdQueries(id));
        
        if (!result.IsSuccess)
        {
          return BadRequest(result.Errors);
        }
        return Ok(result);
        
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> GetAll()
    {
        //var result = _services.GetAll();
        var query = new GetAllBooksQueries();

        var result = await _mediator.Send(query);
        return Ok(result);
        
    }
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Post(InsertBookCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Errors);
        }
        return CreatedAtAction(nameof(FindBookById), new { id = result.Data }, command);
    }

    
    [HttpDelete("{id}")]
    [Authorize (Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteBookCommand(id));
        if (!result.IsSuccess)
        {
            return BadRequest(result.Errors);
        }
        return NoContent();
    }
    
}
