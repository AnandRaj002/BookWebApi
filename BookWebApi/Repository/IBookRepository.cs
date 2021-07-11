using BookWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi.Repository
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAllBooks();
        public Task<Book> GetBook(int Id);
        public Task<Book> AddBook(Book book);
        public Task<Book> UpdateBook(int Id, Book book);
        public Task DeleteBook(int Id);
    }
}
