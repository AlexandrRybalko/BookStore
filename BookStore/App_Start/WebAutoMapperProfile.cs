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
            CreateMap<BookModel, BookModel>();
            CreateMap<BookModel, BookModel>().ReverseMap();

            
        }
    }
}