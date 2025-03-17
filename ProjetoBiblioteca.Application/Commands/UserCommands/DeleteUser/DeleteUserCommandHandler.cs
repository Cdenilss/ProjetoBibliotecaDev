using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Commands.UserCommands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
{
    private readonly IUserRepository _repository;

    public DeleteUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetById(request.Id);

        if (user is null)
        {
            return ResultViewModel.Error("User não encontrado");
        }

        user.SetAsDeleted();
        await _repository.Update(user);
        
            
        return ResultViewModel.Success();
    }
}