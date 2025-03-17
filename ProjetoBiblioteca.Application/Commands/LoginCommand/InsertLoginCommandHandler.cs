using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Auth;

namespace ProjetoBiblioteca.Application.Commands.LoginCommand;

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

        if (user == null || user.Password != hashedPassword)
            return ResultViewModel<string>.Error("Credenciais inválidas.");

        var token = _auth.GenerateToken(user.Id.ToString(), user.Role); 
        return ResultViewModel<string>.Success(token);
    }
}