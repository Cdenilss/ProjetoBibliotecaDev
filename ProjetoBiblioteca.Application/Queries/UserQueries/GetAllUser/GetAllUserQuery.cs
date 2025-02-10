using MediatR;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Services.Queries.UserQueries.GetAllUser;

public class GetAllUserQuery : IRequest<ResultViewModel<List<UserViewModel>>>
{
    
}