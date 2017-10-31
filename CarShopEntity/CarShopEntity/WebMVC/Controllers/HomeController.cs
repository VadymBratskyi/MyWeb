using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(int x, int y)
        {
            ViewBag.Result = x + y;
            return View();
        }

        public ActionResult GoToGoogle()
        {
            return Redirect("http://google.com.ua");
        }

        public ActionResult GoToYoutube()
        {
            return new RedirectResult("http://youtube.com");
        }

        public ActionResult GoToItvdn()
        {
            return RedirectPermanent("http://itvdn.com");
        }

        public ActionResult GoToOtherMethod()
        {
            return RedirectToRoute(new
            {
                controller = "Default",
                action = "MIndex",
                id = "Hello_Other_Method"
            });
        }

        public ActionResult GoToOtherAction()
        {
            return RedirectToAction("Index", "TestRedirect", new {id = "HelloHomeIndex"});
        }

        public ActionResult GoToContent()
        {
            return Content("Hello Content", "text/plain", Encoding.UTF8);
        }

        public ActionResult GoToEmpty()
        {
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult Action1Json()
        {
            var ob = new { Name = "Vadim", Age = 24, Description = "Fan......" };

            return Json(ob, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Action2Json(string name, int year)
        {
            var ob = new { Name = name, Age = year, Description = "Fan......" };

            return Json(ob);
        }
    }
}