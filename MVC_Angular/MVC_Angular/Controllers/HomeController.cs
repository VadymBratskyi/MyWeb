using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Angular.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Spinner()
        {
            return View();
        }

        public ActionResult LoadSpinner()
        {
            return View();
        }

        public ActionResult listView()
        {
            return View();
        }
        public ActionResult tableView()
        {
            return View();
        }

        public ActionResult DomValid()
        {
            return View();
        }
    }
}