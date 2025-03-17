using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Services.Commands.UserCommands.PutUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
{
    private readonly IUserRepository _repository;

    public UpdateUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        var user = await _repository.GetById(request.UserId);

        if (user is null)
        {
            return ResultViewModel.Error("User não encontrado");
        }
        user.Update(request.Name,request.Email);
        
        await _repository.Update(user);
            
        return ResultViewModel.Success();
    }
}