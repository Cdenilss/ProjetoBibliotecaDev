using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Services.Commands.UserCommands.PutUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
{
    private readonly LibraryDbContext _context;

    public UpdateUserCommandHandler(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        
        var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == request.UserId);

        if (user is null)
        {
            return ResultViewModel.Error("User não encontrado");
        }
        user.Update(request.Name,request.Email);
        

        _context.Users.Update(user);
        await _context.SaveChangesAsync();
            
        return ResultViewModel.Sucess();
    }
}