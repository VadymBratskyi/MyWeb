using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
   // public class DefaultController : MyControl
    public class DefaultController : Controller
    {
        //GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MIndex()
        {
            var ll = new List<Product>()
            {
                new Product(){Id = 1, Name = "Item_1", Price = 10},
                new Product(){Id = 2, Name = "Item_2", Price = 20},
                new Product(){Id = 3, Name = "Item_3", Price = 30},
                new Product(){Id = 4, Name = "Item_4", Price = 40},
                new Product(){Id = 5, Name = "Item_5", Price = 50}
            };

            ViewBag.Value = RouteData.Values["id"];
            if (ViewBag.Value==null)
            {
                ViewBag.Value = Request["id"];
            }

            return View(ll);
        }

        public ActionResult GetSumm(int? x, int? y)
        {
            if (x != null && y != null)
            {
                ViewBag.Result = x + y;
            }
            ViewBag.all = RouteData.Values["catchall"];
            return View("MIndex", new List<Product>());
        }


        public ActionResult GetParam(int? id)
        {
            ViewBag.Value = id;

            return View("MIndex", new List<Product>());
        }

        [ChildActionOnly]
        public string GetCurrentDate()
        {
            return DateTime.Today.ToShortDateString();
        }

        public string GetValueParam(string val)
        {
            return "value: "+val;
        }

        public ActionResult MyView()
        {
            ViewBag.Fruits = new string[] { "apple", "orange", "strowbery" };
            ViewBag.Message = "Hello World";
            return View("MyView");
        }

      
        public ActionResult FormResult(string message)
        {
            //var val = Request.Form["message"];
            var val = message;
            return View("MIndex", new List<Product>(){new Product(){Id = 1, Name = val}});
        }
        
    }
}