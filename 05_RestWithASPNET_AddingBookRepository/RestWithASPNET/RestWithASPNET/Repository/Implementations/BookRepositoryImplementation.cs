using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _context;
        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }
        public bool Exists(long id)
        {
            return _context.Books.Any(x => x.Id.Equals(id));
        }
        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }
        public Book FindByID(long id)
        {
            return _context.Books.SingleOrDefault(x => x.Equals(id));
        }
        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }
        public void Delete(long id)
        {
            var searchAndDeploy = _context.Books.SingleOrDefault(x => x.Id.Equals(id));
            if (searchAndDeploy != null)
            {
                try
                {
                    _context.Books.Remove(_context.Books.SingleOrDefault(x => x.Id.Equals(id)));
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;
            var result = _context.Books.SingleOrDefault(x => x.Id.Equals(book.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return book;
        }
    }
}
