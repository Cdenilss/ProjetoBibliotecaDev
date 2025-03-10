using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Application.Commands.LoanCommands.InsertLoan;
using ProjetoBiblioteca.Application.Queries.LoanQuery.GetAllLoans;
using ProjetoBiblioteca.Application.Queries.LoanQuery.GetLoanById;
using ProjetoBiblioteca.Application.Services.Commands.LoanCommands.DeleteLoan;


namespace ProjetoBiblioteca.Controllers
{
    [Route("api/loans")]
    [ApiController]
    [Authorize]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public LoansController(IMediator mediator)
        {
            _mediator = mediator; 
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllLoansQuery();

            var result = await _mediator.Send(query);
            return Ok(result);
           
        }
        
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,user")]
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
        [Authorize(Roles = "admin")]
        
        public async Task<IActionResult> PostLoan(InsertLoanCommands command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLoanById), new { id = result.Data }, command);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
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