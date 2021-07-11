using BookWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi.DataContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> dbOptions):base(dbOptions)
        {

        }

        public DbSet<Book> BookList { get; set; }
    }
}
