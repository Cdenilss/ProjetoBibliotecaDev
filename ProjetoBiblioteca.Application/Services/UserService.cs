using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.InputModels;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Services;

public class UserService : IUserService
{
    private readonly LibraryDbContext _context;

    public UserService(LibraryDbContext context)
    {
        _context = context;
    }
    public ResultViewModel<List<UserViewModel>> GetAll()
    {
        var user = _context.Users
            .Where(u => !u.IsDeleted).ToList();

        if (user==null)
        {
            return ResultViewModel<List<UserViewModel>>.Error("Sem User Cadastrados");
        }

        var model = user.Select(u => UserViewModel.FromEntity(u)).ToList();
        return ResultViewModel<List<UserViewModel>>.Sucess(model); 
    }

    public ResultViewModel<UserViewModel> FindUserById(int id)
    {
        var user = _context.Users
            .Include(u => u.LoansList)
            .ThenInclude(l => l.Book) 
            .SingleOrDefault(u => u.Id == id);

        if (user == null)
        {
            return ResultViewModel<UserViewModel>.Error("User Não encontrado"); 
        }

        var model = UserViewModel.FromEntity(user);

        return ResultViewModel<UserViewModel>.Sucess(model);
    }

    public ResultViewModel<int> Insert(CreateUserInputModel model)
    {
        var user = model.ToEntity();
        _context.Add(user);
        _context.SaveChanges();
        return ResultViewModel<int>.Sucess(user.Id);

    }

    public ResultViewModel Put(int id, UpdateUserInputModel model)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);

        if (user is null)
        {
            return ResultViewModel.Error("User não encontrado");
        }
        
        user.Update(model.Name,model.Email);
        
        _context.Users.Update(user);
        _context.SaveChanges();
            
        return ResultViewModel.Sucess();
    }

    public ResultViewModel Delete(int id)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);

        if (user is null)
        {
            return ResultViewModel.Error("User não encontrado");
        }

        user.SetAsDeleted();
        _context.SaveChanges();
            
        return ResultViewModel.Sucess();
    }
}