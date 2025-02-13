using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Models.InputModels;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Infrastructure.Persistence;

namespace ProjetoBiblioteca.Application.Services
{
    public class BookServices : IBookServices
    {
        private readonly LibraryDbContext _context;

        public BookServices(LibraryDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<BookItemViewModel>> GetAll()
        {
            var books = _context.Books
                .Where(b => !b.IsDeleted).ToList();

            if (books == null)
            {
                return ResultViewModel<List<BookItemViewModel>>.Error("Lista de Livros Vazia");
            }

            var model = books.Select(b => BookItemViewModel.FromEntity(b)).ToList();

            return ResultViewModel<List<BookItemViewModel>>.Sucess(model);
        }

        public ResultViewModel<BookViewModel> FindById(int id)
        {
            var books = _context.Books
                .Include(b => b.Loans)
                .SingleOrDefault(b => b.Id == id);

            if (books == null)
            {
                return ResultViewModel<BookViewModel>.Error("Livro Não Encontrado");
            }

            var model = BookViewModel.FromEntity(books);
            return ResultViewModel<BookViewModel>.Sucess(model);

        }

        public ResultViewModel<int> Insert(CreateBooksInputModel model)
        {
            var book = model.ToEntity();
            _context.Books.Add(book);
            _context.SaveChanges();
            return ResultViewModel<int>.Sucess(book.Id);
        }
       
        public ResultViewModel Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return ResultViewModel.Error("Livro Não encontrado");
            }

            book.SetAsDeleted();
            _context.Update(book);
            _context.SaveChanges();
            return ResultViewModel.Sucess();
        }
    }
}