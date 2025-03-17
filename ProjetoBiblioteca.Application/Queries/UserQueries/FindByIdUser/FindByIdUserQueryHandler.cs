using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Services.Queries.UserQueries.FindByIdUser;

public class FindByIdUserQueryHandler : IRequestHandler<FindByIdUserQuery, ResultViewModel<UserViewModel>>
{
    private readonly IUserRepository _repository;

    public FindByIdUserQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<ResultViewModel<UserViewModel>> Handle(FindByIdUserQuery request, CancellationToken cancellationToken)
    {
        var user =  await _repository.GetDetailsById(request.Id);
        if (user == null)
        {
            return ResultViewModel<UserViewModel>.Error("User Não encontrado"); 
        }

        var model = UserViewModel.FromEntity(user);

        return ResultViewModel<UserViewModel>.Success(model);
    }
}