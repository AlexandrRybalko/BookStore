using BookStore.DAL;
using BookStore.DAL.Repositories;
using LightInject;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Models
{
    public class BookBLModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfPublication { get; set; }
        public decimal Price { get; set; }

        public ICollection<AuthorBLModel> Authors { get; set; }
        public ICollection<GenreBLModel> Genres { get; set; }
        public ICollection<OrderBLModel> Orders { get; set; }
    }
}
