using EF_CF_books.Data;
using EF_CF_books.Models;

namespace EF_CF_books.Repository
{
    public class AuthorRepository
    {
        private readonly BooksContext _bookscontext;

        public AuthorRepository(BooksContext bookscontext)
        {
            _bookscontext = bookscontext;
        }

        public List<Author> GetAll()
        {
            return _bookscontext.Author.ToList();
        }

        public Author GetById(int id)
        {
            return _bookscontext.Author.FirstOrDefault(a => a.ID == id);
        }

        public void DeleteById(int id)
        {
            var aut = _bookscontext.Author.FirstOrDefault(x=>x.ID==id);
            if (aut != null)
            {
                _bookscontext.Author.Remove(aut);
                _bookscontext.SaveChanges();
            }
        }

        public void Create(Author author)
        {
            _bookscontext.Author.Add(author);
            _bookscontext.SaveChanges();
        }

        public void Update(Author author)
        {
            var old_aut = _bookscontext.Author.FirstOrDefault(y=>y.ID==author.ID);
            if (old_aut != null)
            {
                old_aut.Name= author.Name;
                old_aut.Bio= author.Bio;
                old_aut.Ocjena= author.Ocjena;
                _bookscontext.Author.Update(old_aut);
                _bookscontext.SaveChanges();
            }
        }
    }
}
