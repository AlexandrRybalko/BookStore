using BookStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        

        // GET: Cart
        public ActionResult Index()
        {
            return View();
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