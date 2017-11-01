using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class OrdersController : Controller
    {
       // [ThreadStatic]
        private  ProductContext db = new ProductContext();
        
        // GET: Orders
        public ActionResult Index()
        {
            
            ViewBag.Customers = db.Customers.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Index(string id)
        {
            ViewBag.Customers = db.Customers.ToList();
            var custId = Convert.ToInt32(id);
            var ord = db.Orders.FirstOrDefault(o=>o.CustomerId == custId);
            return View("Index", ord);
        }


        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Include(o=>o.Product).Include(o=>o.Customer).FirstOrDefault(o=>o.Id == id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,ProductId,CustomerId,IsAgree")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", orders.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orders.ProductId);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", orders.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orders.ProductId);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,ProductId,CustomerId")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", orders.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", orders.ProductId);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult OrderBody(object id)
        {
            var data = db.Orders.Include(o=>o.Product).Include(o=>o.Customer);
            var ord = id as Orders;
            if (ord != null)
            {
                data = data.Where(o => o.CustomerId == ord.CustomerId);
            }

            return PartialView(data);
        }

        public ActionResult OrderBodyAjax(string id)
        {
            var data = db.Orders.Include(o => o.Product).Include(o => o.Customer);
            var ord = Convert.ToInt32(id);
            if (ord != 0)
            {
                data = data.Where(o => o.CustomerId == ord);
            }
           
            return View("orderBody",data);
        }


        //public ActionResult OrderBodyAjaxJson(string id)
        //{
        //    var data = db.Orders.Include(o => o.Product).Include(o => o.Customer);
        //    var ord = Convert.ToInt32(id);
        //    if (ord != 0)
        //    {
        //        data = data.Where(o => o.CustomerId == ord);
        //    }

        //    return Json(data,JsonRequestBehavior.AllowGet);
        //}

    }
}
