using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Services.Queries.UserQueries.GetAllUser;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, ResultViewModel<List<UserViewModel>>>

{
    private readonly IUserRepository _repository;

    public GetAllUserQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<List<UserViewModel>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetAll();

        if (user==null)
        {
            return ResultViewModel<List<UserViewModel>>.Error("Sem User Cadastrados");
        }

        var model = user.Select(u => UserViewModel.FromEntity(u)).ToList();
        return ResultViewModel<List<UserViewModel>>.Success(model); 
        
    }
}