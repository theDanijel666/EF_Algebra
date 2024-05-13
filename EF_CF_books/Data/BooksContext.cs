using EF_CF_books.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_CF_books.Data
{
    public class BooksContext:DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options):base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
    }
}
