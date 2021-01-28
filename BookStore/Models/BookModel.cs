using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfPublication { get; set; }
        public decimal Price { get; set; }

        public ICollection<AuthorModel> Authors { get; set; }
        public ICollection<GenreModel> Genres { get; set; }
        public ICollection<OrderModel> Orders { get; set; }
    }
}