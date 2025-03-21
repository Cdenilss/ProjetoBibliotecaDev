using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Update.Internal;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Enums;


namespace ProjetoBiblioteca.Core.Entities;

public class User: BaseEntity
{
        public User( string name, string email, bool active, List<Loan> loansList, string password, RoleUserEnum role)
            : base()
        {
            
            Name = name;
            Email = email;
            Active = active;
            Password = password;
            Role = role;
            LoansList = loansList ?? new List<Loan>();
        }
        
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }
        public string Password { get; private set; }
        public RoleUserEnum Role { get; private set; }    

        public List<Loan> LoansList { get; private set; }

        protected User()
        {
        } 

        public User(string name, string email, string password, RoleUserEnum role)
            : base()
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            Active = true;
            LoansList = new List<Loan>();
        }

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }
        
        public void UpdatePassword(string  newPassword)
        {
            Password = newPassword;
        }
    }

