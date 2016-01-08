using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Util;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        BookContext _db = new BookContext();
        // GET: Book
   
        public ActionResult Index()
        {
            IEnumerable<Book> book = _db.Book;
            ViewBag.Books = book;
            ViewBag.Message = "This is partial page with message!!";
            return View(_db.Book);
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            
            if (id>3)
            {
               return Redirect("/Book/Index");
            }
            ViewBag.BookID = id;
            SelectList books = new SelectList(_db.Book,"Name","Author");
            ViewBag.Books = books;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purch, string action, string[] countries)
        {
            if (action == "add")
            {
                purch.Date = DateTime.Now;
                _db.Purchase.Add(purch);
                _db.SaveChanges();
            }
            else if (action == "delete")
            {
                _db.Purchase.Remove(purch);
                _db.SaveChanges();
            }
            else
            {
                return "Error Purchases!!";
            }
            if (countries != null)
            {
                var ss = "";
                foreach (var c in countries)
                {
                    ss += c;
                    ss += "; ";
                }
                return "Спасибо," + purch.Person + ", за покупку!" + "\n Countries: " + ss;
            }
            return "Спасибо," + purch.Person + ", за покупку!";
        }

        public DateTime GetDate()
        {
            return DateTime.Now;
        }

        

        public ActionResult MyAtion()
        {
            return new HtmlResult("<p><h2>Hello World</h2></p>");
        }
        public string Square(/*int a, int b*/)
        {
            //var rez = a*b/2;
            var rez = Int32.Parse(Request.Params["a"]) * Int32.Parse(Request.Params["b"]);
            return "Triangl square: " + rez;
        }

        public ContentResult Square2(int a , int b)
        {
            var rez = a + b;
            return Content(HttpContext.Request.UserHostAddress);
        }

        public FileResult ResultFIl()
        {
            // Путь к файлу
            string file_path = Server.MapPath("~/Files/PDFIcon.pdf");
            // Тип файла - content-type
            string file_type = "application/pdf";
            // Имя файла - необязательно
            string file_name = "PDFIcon.pdf";
            return File(file_path, file_type, file_name);
        }

        public ViewResult Resul()
        {
            return View("Buy");
        }

        public ActionResult Partial()
        {
            return PartialView();
        }
    }
}