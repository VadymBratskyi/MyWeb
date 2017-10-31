using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class ProductsController : Controller
    {
        ProductContext prodDb = new ProductContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(prodDb.Products.ToList());
        }

        public ActionResult CreateProd()
        {
           var pr = new Product();
           return View(pr);
        }

        [HttpPost]
        public ActionResult CreateProd(Product prod)
        {
            if (ModelState.IsValid)
            {
                prodDb.Products.Add(prod);
                prodDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prod);
        }


        public ActionResult Details(int id = 0)
        {
            Product prod = prodDb.Products.Find(id);
            if (prod == null)
            {
                return HttpNotFound();
            }
            return View(prod);
        }


        public ActionResult Edit(int id = 0)
        {
            Product prod = prodDb.Products.Find(id);
            if (prod == null)
            {
                return HttpNotFound();
            }

            return View(prod);
        }
        [HttpPost]
        public ActionResult Edit(Product prod)
        {
            if (prod == null)
            {
                return HttpNotFound();
            }

            var prdb = prodDb.Products.Find(prod.Id);
            if (prdb != null)
            {
                prdb.Name = prod.Name;
                prdb.Price = prod.Price;
                prdb.Description = prod.Description;
                prdb.Role = prod.Role;
                prodDb.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id = 0)
        {
            Product prod = prodDb.Products.Find(id);
            if (prod == null)
            {
                return HttpNotFound();
            }

            return View(prod);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirment(int id = 0)
        {
            Product prod = prodDb.Products.Find(id);
            prodDb.Products.Remove(prod);
            prodDb.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            prodDb.Dispose();
            base.Dispose(disposing);
        }
    }
}