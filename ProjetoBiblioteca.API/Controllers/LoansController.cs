using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Application.Commands.LoanCommands.InsertLoan;
using ProjetoBiblioteca.Application.Models.InputModels;
using ProjetoBiblioteca.Application.Queries.BookQueries.GetAllBooks;
using ProjetoBiblioteca.Application.Queries.LoanQuery.GetAllLoans;
using ProjetoBiblioteca.Application.Queries.LoanQuery.GetLoanById;
using ProjetoBiblioteca.Application.Services;
using ProjetoBiblioteca.Application.Services.Commands.LoanCommands.DeleteLoan;


namespace ProjetoBiblioteca.Controllers
{
    [Route("api/loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _services;
        private readonly IMediator _mediator;
        
        public LoansController(ILoanService services,IMediator mediator)
        {
            _services = services;
            _mediator = mediator; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllLoansQuery();

            var result = await _mediator.Send(query);
            return Ok(result);
           
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanById(int id )
        {
            var result = await _mediator.Send(new GetLoanByIdQuery(id));
        
            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
            
        }        
        [HttpPost]
        
        public async Task<IActionResult> PostLoan(InsertLoanCommands command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLoanById), new { id = result.Data }, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteLoanCommands(id));
            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
        
        
    }
}