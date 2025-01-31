using ProjetoBiblioteca.Application.Models.InputModels;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Services;

public interface ILoanService
{
    ResultViewModel<LoanViewModel> GetLoanById(int id);
    ResultViewModel<int>Insert(CreateLoanInputModel model);
}