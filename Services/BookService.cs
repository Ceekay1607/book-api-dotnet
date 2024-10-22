
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace book_api;

public class BookService : IBookService
{
    private readonly ApplicationDbContext _dbContext;

    public BookService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAsync(CreateBookRequest createBookRequest)
    {
        Book book = ConvertToBookFromBookRequest(createBookRequest);
        await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync();
    }

    private Book ConvertToBookFromBookRequest(CreateBookRequest createBookRequest)
    {
        return new Book { Title = createBookRequest.Title, Author = createBookRequest.Author, Price = createBookRequest.Price };
    }

    public async Task DeleteAsync(int id)
    {
        var book = await GetByIdAsync(id);
        if (book == null)
        {
            throw new CustomException(StatusCodes.Status404NotFound, $"Book with id {id} not found.");
        }

        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();
    }

    public Task<List<Book>> GetAllAsync()
    {
        return _dbContext.Books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        if (book == null)
        {
            throw new CustomException(StatusCodes.Status404NotFound, $"Book with id {id} not found.");
        }
        return book;
    }

    public async Task UpdatePriceAsync(int id, double newPrice)
    {
        var book = await GetByIdAsync(id);
        if (book == null)
        {
           throw new CustomException(StatusCodes.Status404NotFound, $"Book with id {id} not found.");
        }

        if (newPrice < 0)
        {
            throw new CustomException(StatusCodes.Status400BadRequest, $"Price must be a positive number.");
        }

        book.Price = newPrice;
        _dbContext.Books.Update(book);
        await _dbContext.SaveChangesAsync();
    }
}
