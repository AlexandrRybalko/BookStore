using BookStore.DAL;
using BookStore.DAL.Repositories;
using LightInject;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfPublication { get; set; }
        public decimal Price { get; set; }

        public ICollection<AuthorModel> Authors { get; set; }
        public int GenreId { get; set; }
        public GenreModel Genre { get; set; }
        public ICollection<OrderModel> Orders { get; set; }
    }
}
