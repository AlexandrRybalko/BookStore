using AutoMapper;
using BookStore.App_Start;
using BookStore.Domain.Services;
using BookStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [Authorize(Roles = "user")]
    public class CartController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public CartController(IBookService bookService)
        {
            _bookService = bookService;
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WebAutoMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cookieValue = Request.Cookies["books"].Value;
            string[] jsonBooks = cookieValue.Split(' ');
            var books = new List<BookModel>();
            for(int i = 0; i < jsonBooks.Length; i++)
            {
                var deserializedBook = JsonConvert.DeserializeObject<BookModel>(jsonBooks[i]);
                books.Add(deserializedBook);
            }

            return View(books);
        }

        public ActionResult AddToCart(int id)
        {
            var booksCookie = Request.Cookies.Get("books");
            var book = _bookService.GetById(id);
            var bookModel = _mapper.Map<BookModel>(book);
            string jsonBook = JsonConvert.SerializeObject(bookModel);
            if (booksCookie == null)
            {
                Response.Cookies["books"].Value = jsonBook;
                Response.Cookies["books"].HttpOnly = true;

                return RedirectToAction("Index", "Book");
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(booksCookie.Value);
            sb.Append($" {jsonBook}");
            Response.Cookies["books"].Value = sb.ToString();

            /*var booksCookie = Request.Cookies.Get("books");
            if(booksCookie == null)
            {
                Response.Cookies["books"].Value = id.ToString();
                Response.Cookies["books"].HttpOnly = true;

                return RedirectToAction("Index", "Book");
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(booksCookie.Value);
            sb.Append($" {id}");
            Response.Cookies["books"].Value = sb.ToString();*/

            return RedirectToAction("Index", "Book");
        }

        public ActionResult RemoveFromCart(int id)
        {
            var cookieValue = Request.Cookies["books"].Value;
            string[] jsonBooks = cookieValue.Split(' ');
            var books = new List<BookModel>();
            for (int i = 0; i < jsonBooks.Length; i++)
            {
                var deserializedBook = JsonConvert.DeserializeObject<BookModel>(jsonBooks[i]);
                books.Add(deserializedBook);
            }
            books.Remove(books.FirstOrDefault(x => x.Id == id));
            StringBuilder sb = new StringBuilder();
            foreach(var book in books)
            {
                sb.Append(JsonConvert.SerializeObject(book) + " ");
            }
            Response.Cookies["books"].Value = sb.ToString();

            return RedirectToAction("Index", "Cart");
        }



        //    //getdata from cookie
        //    var books = Request.Cookies.Get("bookIds");
        //    vae booksd = JsonConvert.DeserializeObject<BookCoockieModel>(books.Value);

        //    var respCoockies = new System.Web.HttpCookie("bookIds");
        //    respCoockies.Value = JsonConvert.SerializeObject(booksd);
        //    respCoockies.HttpOnly = true;

        //    Response.Cookies.Add(respCoockies);

    }
}