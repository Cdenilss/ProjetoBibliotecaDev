using System.ComponentModel.DataAnnotations;
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
    
    public Loan Loan{ get; private set; }
    public Book Book { get; private set; }
    protected User() { }
   
    public User(string name, string email, int id)
        : base()
    {
        // Guarda os valores
        Name = name;
        Email = email;
        Id = id;
        Active = true;
        LoansList= [];
    }

    public void Update(string name, string email)
    {
        Name = name;
        Email = email;
    }
    
}