using BookWebApi.DataContext;
using BookWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi.Repository
{
    public class DefaultBookRepository : IBookRepository
    {
        private AppDBContext bookDbContext;

        public DefaultBookRepository(AppDBContext appDBContext)
        {
            this.bookDbContext = appDBContext;
        }

        public async Task<Book> AddBook(Book book)
        {
            var result = await bookDbContext.BookList.AddAsync(book);
            await bookDbContext.SaveChangesAsync();

            return result.Entity;            
        }

        public async Task DeleteBook(int Id)
        {
            var result = await bookDbContext.BookList.FirstOrDefaultAsync(b => b.BookId == Id);

            if(result != null)
            {
                bookDbContext.BookList.Remove(result);
                await bookDbContext.SaveChangesAsync();
            }            
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await bookDbContext.BookList.ToListAsync();
        }

        public async Task<Book> GetBook(int Id)
        {
            return await bookDbContext.BookList.FirstOrDefaultAsync(b => b.BookId == Id);            
        }

        public async Task<Book> UpdateBook(int Id, Book book)
        {
            var result = await bookDbContext.BookList.FirstOrDefaultAsync(b => b.BookId == Id);

            if (result == null)
                return null;
            else
            {
                result.BookName = book.BookName;
                result.Descriptions = book.Descriptions;
                result.AuthorName = book.AuthorName;
                result.Category = book.Category;
                result.Price = book.Price;

                await bookDbContext.SaveChangesAsync();

                return result;
            }
        }
    }
}
