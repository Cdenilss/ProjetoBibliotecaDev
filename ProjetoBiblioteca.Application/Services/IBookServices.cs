using ProjetoBiblioteca.Application.Models.InputModels;
using ProjetoBiblioteca.Application.Models.ViewModel;

namespace ProjetoBiblioteca.Application.Services
{

    public interface IBookServices
    {
        ResultViewModel<List<BookItemViewModel>> GetAll();
        ResultViewModel<BookViewModel> FindById(int id);
        ResultViewModel<int> Insert(CreateBooksInputModel model);
        ResultViewModel Delete(int id);
    }
}