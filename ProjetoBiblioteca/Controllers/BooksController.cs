using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Models;
using ProjetoBiblioteca.Models.ViewModel;
using ProjetoBiblioteca.Persistence;

namespace ProjetoBiblioteca.Controllers{
    [Route("api/Books")]
    [ApiController]


public class BooksController : ControllerBase
{

    private readonly LibaryDbContext _context;

    public BooksController(LibaryDbContext context)
    {
        _context = context;
    }

    [HttpGet ("search")]
    public IActionResult Get(string search)
    {
        var books = _context.Books
            .Include(b=>b.Titulo)
            .Include(b=>b.Status)
            .Where(b => b.IsDeleted).ToList();
        var model= books.Select(BookViewModel.FromEntity).ToList();
        return Ok(model);
    }
    
    [HttpGet("{id}")]

    public IActionResult GetById(int id)
    {
        var books = _context.Books
            .Include(b => b.Titulo)
            .Include(b => b.Status)
            .Include(b => b.Autor)
            .SingleOrDefault(b => b.Id == id);

        var model = BookViewModel.FromEntity(books);
        return Ok(model);
        
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }
    
     
    [HttpPost]
    public IActionResult Post(CreateBooksInputModel model)
    {
        var book = model.ToEntity();
        _context.Books.Add(book);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
    }

    [HttpPut("{id}")]
    public IActionResult PutBook()
    {
         return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
}