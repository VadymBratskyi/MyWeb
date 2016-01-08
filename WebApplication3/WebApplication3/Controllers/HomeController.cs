using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        SoccerContext _db = new SoccerContext();

        // GET: Home
        public ActionResult Index()
        {
            var pl = _db.Players.Include(p => p.Team);
            return View(pl.ToList());
        }

        public ActionResult Create()
        {
            SelectList sel = new SelectList(_db.Teams,"Id","Name");
            ViewBag.Teams = sel;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Player player)
        {
            _db.Entry(player).State = EntityState.Added;
            _db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Player pl = _db.Players.Find(id);
            if (pl != null)
            {
                SelectList lis = new SelectList(_db.Teams,"Id","Name",pl.TeamId);
                ViewBag.Teams = lis;
                return View(pl);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            _db.Entry(player).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var pl = _db.Players.Include(t => t.Team).FirstOrDefault(t => t.Id == id);
            return View(pl);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePlayer(int? id)
        {
            Player pl = _db.Players.Find(id);
            _db.Entry(pl).State = EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Info(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var pl = _db.Players.Include(t => t.Team).FirstOrDefault(p => p.Id == id);
            return View(pl);
        }
       

    }
}