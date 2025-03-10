using Bogus;
using ProjetoBiblioteca.Application.Commands.BookCommands.DeleteBook;
using ProjetoBiblioteca.Application.Commands.BookCommands.InsertBook;
using ProjetoBiblioteca.Application.Services.Commands.UserCommands.InsertUser;
using ProjetoBiblioteca.Core.Entities;
using ProjetoBiblioteca.Core.Enums;

namespace TestProject2.Fakes;

public class FakesDataHelper
{
    private static readonly Faker _faker = new Faker();

    public static Book CreateFakeBookV1()
    {
        return new Book(

            _faker.Random.Words(1),
            _faker.Person.FullName,
            _faker.Commerce.Ean13(),
            _faker.Random.Int(0, 2025),
            _faker.PickRandom<BookStatusEnum>()
            );

    }
    
    private static readonly Faker<Book> _fakerBook = new Faker<Book>()
        .CustomInstantiator(f => new Book(
            f.Random.Words(1),
            f.Person.FullName,
            f.Commerce.Ean13(),
            f.Random.Int(0, 2025),
            f.PickRandom<BookStatusEnum>()
        ));
    
    private static readonly Faker<InsertBookCommand> _insertBookCommandFaker = new Faker<InsertBookCommand>()
        .RuleFor(b=>b.Title,f=>f.Random.Words(1))
        .RuleFor(b=> b.Author,f=>f.Person.FullName)
        .RuleFor(b=>b.ISBN,f=>f.Commerce.Ean13())
        .RuleFor(b=>b.YearOfPublication,f=>f.Random.Int(0,2025));
    
    public static Book CreateFakeBook()=> _fakerBook.Generate();
    public static List<Book> CreateFakeBookList()=> _fakerBook.Generate(10);
    public static InsertBookCommand CreateFakeInsertBookCommand()=> _insertBookCommandFaker.Generate();
    
    
    
    public static readonly Faker<User>_fakerUser= new Faker<User>()
        .CustomInstantiator(f => new User(
            f.Person.FullName,
            f.Person.Email,
            f.Random.Hash(),
            f.Person.Random.AlphaNumeric(5)
            
        ));
   
    private static readonly Faker<InsertUserCommand> _insertUserCommandFaker = new Faker<InsertUserCommand>()
        .RuleFor(u=>u.Name,f=>f.Person.FullName)
        .RuleFor(u=>u.Email,f=>f.Person.Email)
        .RuleFor(u=>u.Password,f=>f.Random.Hash())
        .RuleFor(u=>u.Role,f=>f.Person.Random.AlphaNumeric(5))
        ;
    
    public static List<User> CreateFakeUserList()=> _fakerUser.Generate(10);
    public static InsertUserCommand CreateFakeInsertUserCommand()=> _insertUserCommandFaker.Generate();
    public static User CreateFakeUser()=> _fakerUser.Generate();
    
    public static readonly Faker<Loan>_fakerLoan= new Faker<Loan>()
        .CustomInstantiator(f => new Loan(
            f.Random.Int(1,100),
            f.Random.Int(1,100),
            f.Date.Past(),
            f.Date.Future()
        ));
    
    public static Loan CreateFakeLoan()=> _fakerLoan.Generate();
    public static List<Loan> CreateFakeLoanList()=> _fakerLoan.Generate(10);
    
    public static DeleteBookCommand CreateFakeDeleteBookCommand(int id)
    {
        return new DeleteBookCommand(id);
    }
    
    
}