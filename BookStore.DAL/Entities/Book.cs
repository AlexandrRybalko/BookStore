using BookStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfPublication { get; set; }
        public decimal Price { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }

        public ICollection<Author> Authors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
