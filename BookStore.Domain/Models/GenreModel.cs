using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<BookModel> Books { get; set; }
    }
}
