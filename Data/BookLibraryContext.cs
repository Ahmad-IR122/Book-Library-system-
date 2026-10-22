using Microsoft.EntityFrameworkCore;
using BookLibrary.Models;

namespace BookLibrary.Data
{
  public class BookLibraryContext : DbContext
  {
    public BookLibraryContext(DbContextOptions<BookLibraryContext> options)
          : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Book>().ToTable("Books");
    }

  }
}