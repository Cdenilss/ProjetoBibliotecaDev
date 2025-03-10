namespace ProjetoBiblioteca.Application.Models;

public class RecoveryModels
{
    public class PasswordRecoveryRequestInputModel
    {
        public string Email { get; set; }
    }
    
    public class ValidateRecoveryCodeInputModel
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
    
    public class ResetPasswordInputModel
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string NewPassword { get; set; }
    }
}