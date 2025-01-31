using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ProjetoBiblioteca.Application.Models.InputModels;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Services;

public interface IUserService
{
    ResultViewModel<List<UserViewModel>> GetAll();
    ResultViewModel<UserViewModel> FindUserById(int id);
    ResultViewModel<int> Insert(CreateUserInputModel model);
    ResultViewModel Put(int id, UpdateUserInputModel model);
    ResultViewModel Delete(int id);
}