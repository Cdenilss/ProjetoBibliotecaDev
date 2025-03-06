using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Auth;

namespace ProjetoBiblioteca.Application.Commands.LoginCommand;

public class InsertLoginCommand : IRequest<ResultViewModel<string>>
{
    private readonly IAuthService _auth;
    public InsertLoginCommand(IAuthService auth)
    {
        _auth = auth;
    }
    
    public InsertLoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
    
    public string Email { get;  set; }
    public string Password { get;  set; }
}


public class InsertLoginCommandHandler : IRequestHandler<InsertLoginCommand, ResultViewModel<string>>
{
    private readonly IUserRepository _repository;
    private readonly IAuthService _auth;

    public InsertLoginCommandHandler(IUserRepository repository, IAuthService auth)
    {
        _repository = repository;
        _auth = auth;
    }

    public async Task<ResultViewModel<string>> Handle(InsertLoginCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = _auth.ComputeHash(request.Password);
        var user = await _repository.GetByEmail(request.Email);
        if (user == null)
        {
            return ResultViewModel<string>.Error("User not found.");
        }

        if (user.Password != hashedPassword)
        {
            return ResultViewModel<string>.Error("Invalid password.");
        }

        var token = _auth.GenerateToken(user.Password, user.Role);
        return ResultViewModel<string>.Sucess(token);
    }
}
