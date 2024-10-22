namespace book_api;

public interface IBookService
{
    Task<Book?> GetByIdAsync (int id);
    Task<List<Book>> GetAllAsync ();
    Task AddAsync (CreateBookRequest createBookRequest);
    Task DeleteAsync(int id);
    Task UpdatePriceAsync(int id, double newPrice);

}
