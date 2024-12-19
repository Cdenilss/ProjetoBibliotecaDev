using Microsoft.EntityFrameworkCore.Update.Internal;

namespace ProjetoBiblioteca.Entites;

public class User: BaseEntity
{
    public User(int id, string name, string email, bool active, List<Loan> loansList)
    :base()
    {
        Id = id;
        Name = name;
        Email = email;
        Active = active;
        LoansList = [];
    }

    public int  Id { get; private set; }
    
    public string Name { get; private set; }
    public string  Email { get; private set; }
    public bool Active { get; private set; }

    public List<Loan> LoansList { get; private set; }



    public void  Update(string email)
    { 
        Email = email;
    }
        
}