using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Application.Services.Commands.UserCommands.InsertUser;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Auth;

namespace ProjetoBiblioteca.Application.Commands.UserCommands.InsertUser;

public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
{
    private readonly IUserRepository _repository;
    private readonly IAuthService _auth;
  
    public InsertUserCommandHandler(IUserRepository repository, IAuthService auth)
    {
        _repository = repository;
        _auth = auth;
    }
    
    public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = _auth.ComputeHash(request.Password); 
        var user = request.ToEntity(hashedPassword);
        var id= await _repository.Add(user);
        return ResultViewModel<int>.Sucess(id);
    }
}