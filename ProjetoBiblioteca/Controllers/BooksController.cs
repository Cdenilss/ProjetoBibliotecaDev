using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Enums;
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
    
    [HttpGet("{id}")]

    public IActionResult FindBookById(int id)
    {
        var books = _context.Books
            .Include(b=>b.Loans)
            .SingleOrDefault(b => b.Id == id);

        if (books==null)
        {
            return NotFound();
        }

        var model = BookViewModel.FromEntity(books);
        return Ok(model);
        
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {

        var books = _context.Books
            .Where(b => !b.IsDeleted).ToList();

        if (books == null)
        {
            return NotFound();
        }
        var model = books.Select(b=>BookItemViewModel.FromEntity(b)).ToList();
        
        return Ok(model);
    }
    
     
    [HttpPost]
    public IActionResult Post(CreateBooksInputModel model)
    {
        var book =  model.ToEntity();
        _context.Books.Add(book);
        _context.SaveChanges();
        return CreatedAtAction(nameof(FindBookById), new { id = book.Id }, model);
    }

    [HttpPut("{id}/Loaned")]
    public IActionResult Loaned(int id)
    {
        var book = _context.Books.SingleOrDefault(b => b.Id == id);

        if (book.Status != BookStatusEnum.Available)
        {
            return BadRequest();
        }

        book.Loaned();
        _context.Update(book);
        _context.SaveChanges();
        return Created();
    }
   
    [HttpPut("{id}/MakesAvailable")]
    public IActionResult MakesAvailable(int id)
    {
        var book = _context.Books.SingleOrDefault(b => b.Id == id);

        if (book == null)
        {
            return NotFound();
        }
        book.MakesAvailable();
        _context.Update(book);
        _context.SaveChanges();
        return Created();
        
        
    }
    [HttpPut("{id}/Reserved")]
    public IActionResult Reserved(int id)
    {
        var book = _context.Books.SingleOrDefault(b => b.Id == id);

        if (book.Status != BookStatusEnum.Available)
        {
            return BadRequest();
        }
        book.Reserved();
        _context.Update(book);
        _context.SaveChanges();
        return Created();

    }
    [HttpPut("{id}/MakesUnvailable")]
    public IActionResult MakesUnvailable(int id)
    {
        var book = _context.Books.SingleOrDefault(b => b.Id == id);

        if (book== null)
        {
            return NotFound();
        }
        book.MarkAsUnavailable();
        _context.Update(book);
        _context.SaveChanges();
        return Created();

    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = _context.Books.SingleOrDefault(b => b.Id == id);
        if (book is null)
        {
            return NotFound();
        }
        book.SetAsDeleted();
        _context.Update(book);
        _context.SaveChanges();
        return NoContent();

    }
    
}
}