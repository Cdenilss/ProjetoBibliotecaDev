using ProjetoBiblioteca.Core.Entities;

namespace ProjetoBiblioteca.Core.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User?> GetDetailsById(int id);
    Task<User?> GetById(int id);
    Task<int> Add(User user);
    Task<bool> Exists(int id);
    Task Update(User user);
    Task<User> GetByEmail(string requestEmail);
    Task UpdatePassword(User user,string newPassword);
}