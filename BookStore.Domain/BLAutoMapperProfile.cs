using AutoMapper;
using BookStore.DAL.Entities;
using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain
{
    public class BLAutoMapperProfile : Profile
    {
        public BLAutoMapperProfile()
        {
            CreateMap<Book, BookBLModel>();
            CreateMap<Book, BookBLModel>().ReverseMap();

            CreateMap<Genre, GenreBLModel>();
            CreateMap<Genre, GenreBLModel>().ReverseMap();

            CreateMap<Author, AuthorBLModel>();
            CreateMap<Author, AuthorBLModel>().ReverseMap();

        }
    }
}
