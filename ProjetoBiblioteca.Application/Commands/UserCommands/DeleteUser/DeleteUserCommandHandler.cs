using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Commands.UserCommands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
{
    private readonly LibraryDbContext _context;

    public DeleteUserCommandHandler(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

        if (user is null)
        {
            return ResultViewModel.Error("User não encontrado");
        }

        user.SetAsDeleted();
        await _context.SaveChangesAsync();
            
        return ResultViewModel.Sucess();
    }
}