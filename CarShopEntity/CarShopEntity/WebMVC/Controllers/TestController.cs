using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            var prod = new Product()
                {Id = 1, Name = "Item_1", Price = 10, Description ="adssad", Role = Role.User};
        
            return View(prod);
        }
    }
}