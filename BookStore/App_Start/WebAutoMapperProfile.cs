using AutoMapper;
using BookStore.Domain.Models;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.App_Start
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<BookBLModel, BookModel>();
            CreateMap<BookBLModel, BookModel>().ReverseMap();

            CreateMap<AuthorBLModel, AuthorModel>();
            CreateMap<AuthorBLModel, AuthorModel>().ReverseMap();

            CreateMap<GenreBLModel, GenreModel>();
            CreateMap<GenreBLModel, GenreModel>().ReverseMap();
        }
    }
}