using ProjetoBiblioteca.Core.Entities;

namespace ProjetoBiblioteca.Core.Repositories;

public interface IBookRepository
{
    Task<List<Book>> GetAll();
    Task<Book?> GetDetailsById(int id);
    Task<Book?> GetById(int id);
    Task<int> Add(Book book);
    Task<bool> Exists(int id);
    Task Update(Book book);
    Task<bool> ExistsByTitle(string title);
    Task<bool>LoansActive(int id);
    

}