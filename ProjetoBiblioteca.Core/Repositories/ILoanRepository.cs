using ProjetoBiblioteca.Core.Entities;

namespace ProjetoBiblioteca.Core.Repositories;

public interface ILoanRepository
{
    Task<List<Loan>> GetAll();
    Task<Loan?> GetDetailsById(int id);
    Task<Loan?> GetById(int id);
    Task<int> Add(Loan loan);
    Task<bool> Exists(int id);
    Task Update(Loan loan);
}