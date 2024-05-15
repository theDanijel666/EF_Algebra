using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;

namespace EF_Migracije.Models
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        public DbSet<Book> Book { get; set;}
        public DbSet<Author> Author { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    ID = 1,
                    Name="Ivana Brlić-Mažuranić",
                    Bio="Hrvatska književnica poznata po dječijim pričama",
                    Ocjena=4
                },
                new Author
                {
                    ID = 2,
                    Name = "Miroslav Krleža",
                    Bio = "Pisac",
                    Ocjena = 2
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { ID = 1, Title="Šegrt Hlapić", Description="", Genre="Bajka", Stock=10, ReleaseDate=DateTime.Now, AuthorId=1 },
                new Book { ID = 2, Title = "Šegrt Hlapić 2", Description = "", Genre = "Bajka", Stock = 14, ReleaseDate = DateTime.Now, AuthorId = 1 },
                new Book { ID = 3, Title = "Šegrt Hlapić 3", Description = "", Genre = "Bajka", Stock = 26, ReleaseDate = DateTime.Now, AuthorId = 1 },
                new Book { ID = 4, Title = "Zlatarevo Zlato", Description = "", Genre = "Drama", Stock = 4, ReleaseDate = DateTime.Now, AuthorId = 2 }
            );
        }
    }
}
