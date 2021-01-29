using AutoMapper;
using BookStore.App_Start;
using BookStore.Domain.Models;
using BookStore.Domain.Services;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WebAutoMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        // GET: Book
        public ActionResult Index()
        {
            var books = _bookService.GetAll();
            var bookModels = _mapper.Map<IEnumerable<BookModel>>(books);

            return View(bookModels);
        }
    }
}