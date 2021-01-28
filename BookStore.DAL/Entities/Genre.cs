using BookStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
