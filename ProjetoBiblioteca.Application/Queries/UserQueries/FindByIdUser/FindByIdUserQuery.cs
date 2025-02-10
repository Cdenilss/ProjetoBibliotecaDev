using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Services.Queries.UserQueries.FindByIdUser;

public class FindByIdUserQuery : IRequest<ResultViewModel<UserViewModel>>
{
    public FindByIdUserQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
    
}