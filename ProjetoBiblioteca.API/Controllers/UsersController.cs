using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoBiblioteca.Application.Commands.LoginCommand;
using ProjetoBiblioteca.Application.Commands.UserCommands.DeleteUser;
using ProjetoBiblioteca.Application.Models.InputModel;
using ProjetoBiblioteca.Application.Services.Commands.UserCommands.InsertUser;
using ProjetoBiblioteca.Application.Services.Commands.UserCommands.PutUser;
using ProjetoBiblioteca.Application.Services.Queries.UserQueries.FindByIdUser;
using ProjetoBiblioteca.Application.Services.Queries.UserQueries.GetAllUser;


namespace ProjetoBiblioteca.Controllers
{

    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUserQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindUserById(int id)
        {
            var result = await _mediator.Send(new FindByIdUserQuery(id));
            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);

        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostUser(InsertUserCommand command)
        {

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(FindUserById), new { id = result.Data }, command);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand(id));
            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(InsertLoginCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
            {
                return BadRequest(new { message = result.Message }); 
            }

            return Ok(new { token = result.Data }); 
        }

    }
}