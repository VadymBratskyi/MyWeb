using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class TeamsController : Controller
    {
        SoccerContext _db = new SoccerContext();
        // GET: Teams
        public ActionResult Index()
        {
            var tt = _db.Teams.Include(p => p.Players);
            return View(tt.ToList());
        }

        public ActionResult Info(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var pp = _db.Teams.Include(t => t.Players).FirstOrDefault(p => p.Id == id);
            return View(pp);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Team t = _db.Teams.Find(id);
            return View(t);
        }

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if (team == null)
            {
                return HttpNotFound();
            }
            _db.Entry(team).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index","Teams");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            var tt = _db.Teams.Include(t => t.Players).FirstOrDefault(p => p.Id == id);
            return View(tt);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteT(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            Team tt = _db.Teams.Find(id);
            _db.Entry(tt).State = EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction("Index", "Teams");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Team team)
        {
            _db.Entry(team).State = EntityState.Added;
            _db.SaveChanges();
            return RedirectToAction("Index","Teams");
        }

    }
}