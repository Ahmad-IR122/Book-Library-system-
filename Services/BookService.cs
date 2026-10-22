using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace BookLibrary.Services
{
  public class BookServise
  {
    private readonly BookLibraryContext _context;

    public BookServise(BookLibraryContext context)
    {
      _context = context;
    }

    public async Task<List<Book>> GetAllBookAsync()
    {
      return await _context.Books.OrderByDescending(b => b.CreatedAt).ToListAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
      return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<bool> CreateBookAsync(Book book)
        {
            try
            {
                book.CreatedAt = DateTime.UtcNow;
                book.UpdatedAt = DateTime.UtcNow;
                book.PublishedDate = NormalizeToUtc(book.PublishedDate);
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        // UPDATE
        public async Task<bool> UpdateBookAsync(int id, Book book)
        {
            try
            {
                var existing = await _context.Books.FindAsync(id);
                if (existing == null) return false;

                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.ISBN = book.ISBN;
                existing.Description = book.Description;
                existing.Price = book.Price;
                existing.Quantity = book.Quantity;
                existing.Genre = book.Genre;
                existing.PublishedDate = NormalizeToUtc(book.PublishedDate);
                existing.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        private static DateTime NormalizeToUtc(DateTime value)
        {
            return value.Kind switch
            {
                DateTimeKind.Utc => value,
                DateTimeKind.Local => value.ToUniversalTime(),
                _ => DateTime.SpecifyKind(value, DateTimeKind.Utc)
            };
        }

        // DELETE
        public async Task<bool> DeleteBookAsync(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null) return false;

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}