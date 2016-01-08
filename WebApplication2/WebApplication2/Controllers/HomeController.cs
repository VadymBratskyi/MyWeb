using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Books);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult EditModel(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book bk = db.Books.Find(id);
            if (bk!=null)
            {
                return View(bk);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditModel(Book book)
        {
            db.Entry(book).State =EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            //db.Books.Add(book);
            db.Entry(book).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult InfoModel(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book bk = db.Books.Find(id);
            if (bk != null)
            {
                return View(bk);
            }
            return HttpNotFound();
        }
        
        //public ActionResult DeleteModel(int id)
        //{
        //    //Book bb = db.Books.Find(id);
        //    //if (bb != null)
        //    //{
        //    //    db.Books.Remove(bb);
        //    //    db.SaveChanges();
        //    //}
        //    Book bk = new Book() {Id = id};
        //    db.Entry(bk).State = EntityState.Deleted;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book b = db.Books.Find(id);
            if (b==null)
            {
                return HttpNotFound();
            }
            return View(b);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book b = db.Books.Find(id);
            if (b==null)
            {
                return HttpNotFound();
            }
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}