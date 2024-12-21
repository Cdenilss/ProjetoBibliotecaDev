using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoBiblioteca.Entites;

namespace ProjetoBiblioteca.Persistence;

public class LibaryDbContext : DbContext
{
    public LibaryDbContext(DbContextOptions<LibaryDbContext> options) : base(options)
    {
        
    }

    public DbSet<Book> Books { get;  set; }
    public DbSet<User> User { get;  set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>(e =>
        {
            e.HasKey(b => b.Id);
            
        });
        builder.Entity<User>(e =>
        {
            e.HasKey(u => u.Id);
            e.HasMany(u => u.LoansList)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.IdUser);
        });
        builder.Entity<Loan >(e =>
        {
            e.HasKey(l => l.Id);
            e.HasOne(l => l.Book)
                .WithMany()
                .HasForeignKey(l => l.IdBook);
        });
        

    }
}