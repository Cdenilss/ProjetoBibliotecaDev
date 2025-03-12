using ProjetoBiblioteca.Core.Enums;

namespace ProjetoBiblioteca.Infrastructure.Auth;

public interface  IAuthService
{
    string ComputeHash(string password);
    string GenerateToken(string email, RoleUserEnum role);
    
    
}