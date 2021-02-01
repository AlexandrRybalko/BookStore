using AutoMapper;
using BookStore.App_Start;
using BookStore.Domain.Models;
using BookStore.Domain.Services;
using BookStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [AllowAnonymous]
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

        public ActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);
            var bookModel = _mapper.Map<BookModel>(book);

            return View("/Views/Book/Book.cshtml", bookModel);
        }


        /*[Authorize(Roles = "user")]
        public ActionResult GetMyBooks(string userId)
        {
            var myBooks = _

            return View();
        }*/
    }
}