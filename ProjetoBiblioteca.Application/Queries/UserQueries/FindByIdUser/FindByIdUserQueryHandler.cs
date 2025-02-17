using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Services.Queries.UserQueries.FindByIdUser;

public class FindByIdUserQueryHandler : IRequestHandler<FindByIdUserQuery, ResultViewModel<UserViewModel>>
{
    private readonly LibraryDbContext _context;

    public FindByIdUserQueryHandler(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<UserViewModel>> Handle(FindByIdUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(u => u.LoansList)
            .ThenInclude(l => l.Book)
            .SingleOrDefaultAsync(u => u.Id == request.Id);

        if (user == null)
        {
            return ResultViewModel<UserViewModel>.Error("User Não encontrado"); 
        }

        var model = UserViewModel.FromEntity(user);

        return ResultViewModel<UserViewModel>.Sucess(model);
    }
}