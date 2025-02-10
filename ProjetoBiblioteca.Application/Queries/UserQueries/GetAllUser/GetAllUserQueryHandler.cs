using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Services.Queries.UserQueries.GetAllUser;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, ResultViewModel<List<UserViewModel>>>

{
    private readonly LibraryDbContext _context;

    public GetAllUserQueryHandler(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Where(u => !u.IsDeleted).ToListAsync();

        if (user==null)
        {
            return ResultViewModel<List<UserViewModel>>.Error("Sem User Cadastrados");
        }

        var model = user.Select(u => UserViewModel.FromEntity(u)).ToList();
        return ResultViewModel<List<UserViewModel>>.Sucess(model); 
        
    }
}