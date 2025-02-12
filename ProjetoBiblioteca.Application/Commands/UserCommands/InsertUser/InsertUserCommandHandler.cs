using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Services.Commands.UserCommands.InsertUser;

public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
{
    private readonly LibraryDbContext _context;

    public InsertUserCommandHandler(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var user =  request.ToEntity();
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return ResultViewModel<int>.Sucess(user.Id);
    }
}