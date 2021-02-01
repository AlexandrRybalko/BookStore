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
using Microsoft.AspNet.Identity;
using BookStore.Domain.Models;

namespace BookStore.Controllers
{
    [Authorize(Roles = "user")]
    public class CartController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public CartController(IBookService bookService, IOrderService orderService)
        {
            _bookService = bookService;
            _orderService = orderService;
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<WebAutoMapperProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }

        // GET: Cart
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Request.Cookies["books"] == null || String.IsNullOrEmpty(Request.Cookies["books"].Value))
            {
                return View("/Views/Cart/Empty.cshtml");
            }

            string[] cookieValues = Request.Cookies["books"].Value.Split('d');
            List<int> ids = new List<int>();
            for (int i = 0; i < cookieValues.Length; i++)
            {
                ids.Add(int.Parse(cookieValues[i]));
            }
            var books = _bookService.GetAll().Where(x => ids.Contains(x.Id));
            var bookModels = _mapper.Map<IEnumerable<BookModel>>(books);

            return View(bookModels);
        }


        public JsonResult AddToCart(int id)
        {
            var booksCookie = Request.Cookies.Get("books");
            if (Request.Cookies.Get("books") == null)
            {
                Response.Cookies["books"].Value = $"{id}";
                Response.Cookies["books"].HttpOnly = true;
            }
            else
            {
                if (Request.Cookies.Get("books").Value.Contains($"{id}"))
                {
                    return Json(new { result = "The item has been already added" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(booksCookie.Value);
                    sb.Append($"d{id}");
                    Response.Cookies["books"].Value = sb.ToString();
                }                
            }

            return Json(new { result = "Item added" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveFromCart(int id)
        {
            var cookieValue = Request.Cookies["books"].Value.Split('d');
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < cookieValue.Length; i++)
            {
                if(cookieValue[i] != id.ToString())
                {
                    sb.Append($"{cookieValue[i]}d");
                }
            }
            if(sb.Length >= 1)
            {
                sb.Length--;
            }
            Response.Cookies["books"].Value = sb.ToString();

            return RedirectToAction("Index", "Cart");
        }

        public void ClearCart()
        {
            if (Request.Cookies["books"] != null)
            {
                Response.Cookies["books"].Expires = DateTime.Now.AddDays(-1);
            }
        }

        public ActionResult CreateOrder()
        {
            string[] booksIds = Request.Cookies["books"].Values["ids"].Split(' ');
            List<int> ids = new List<int>();
            for(int i = 0; i < booksIds.Length; i++)
            {
                ids.Add(int.Parse(booksIds[i]));
            }

            var books = _bookService.GetAll().Where(x => ids.Contains(x.Id));
            var bookModels = _mapper.Map<IEnumerable<BookModel>>(books);
            var orderModel = new OrderModel { CreatedDate = DateTime.Now, UserId = User.Identity.GetUserId(), Books = bookModels };
            var order = _mapper.Map<OrderBLModel>(orderModel);
            _orderService.Create(order);
            ClearCart();

            return RedirectToAction("Index", "Book");
        }
    }

        //    //getdata from cookie
        //    var books = Request.Cookies.Get("bookIds");
        //    vae booksd = JsonConvert.DeserializeObject<BookCoockieModel>(books.Value);

        //    var respCoockies = new System.Web.HttpCookie("bookIds");
        //    respCoockies.Value = JsonConvert.SerializeObject(booksd);
        //    respCoockies.HttpOnly = true;

        //    Response.Cookies.Add(respCoockies);

}
