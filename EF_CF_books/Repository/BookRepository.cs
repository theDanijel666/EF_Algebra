using EF_CF_books.Data;
using EF_CF_books.Models;
using Microsoft.CodeAnalysis.Operations;

namespace EF_CF_books.Repository
{
    public class BookRepository
    {
        private readonly BooksContext _bookscontext;

        public BookRepository(BooksContext bookscontext)
        {
            _bookscontext = bookscontext;
        }

        public List<Book> GetAllBooks()
        {
            return _bookscontext.Book.ToList();
        }

        public Book GetBook(int id)
        {
            var book = _bookscontext.Book.FirstOrDefault(
                b => b.ID == id);
            if (book != null)
            {
                book.Author = _bookscontext.Author.FirstOrDefault
                    (a => a.ID == book.AuthorId);
            }
            return book;
        }
    }
}
