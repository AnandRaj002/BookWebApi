using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Descriptions { get; set; }
        public string AuthorName { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
    }
}
