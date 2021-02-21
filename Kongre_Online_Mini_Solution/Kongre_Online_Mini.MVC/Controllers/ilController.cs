using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kongre_Online_Mini.MVC.Models;

namespace Kongre_Online_Mini.MVC.Controllers
{
    [Authorize]
    public class ilController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: il
        public ActionResult Index()
        {
            var il = db.il.Include(i => i.Bolge);
            return View(il.ToList());
        }

        // GET: il/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            il il = db.il.Find(id);
            if (il == null)
            {
                return HttpNotFound();
            }
            return View(il);
        }

        // GET: il/Create
        public ActionResult Create()
        {
            ViewBag.BolgeId = new SelectList(db.Bolge, "BolgeId", "BolgeAdi");
            return View();
        }

        // POST: il/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ilId,ilAdi,BolgeId")] il il)
        {
            if (ModelState.IsValid)
            {
                db.il.Add(il);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BolgeId = new SelectList(db.Bolge, "BolgeId", "BolgeAdi", il.BolgeId);
            return View(il);
        }

        // GET: il/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            il il = db.il.Find(id);
            if (il == null)
            {
                return HttpNotFound();
            }
            ViewBag.BolgeId = new SelectList(db.Bolge, "BolgeId", "BolgeAdi", il.BolgeId);
            return View(il);
        }

        // POST: il/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ilId,ilAdi,BolgeId")] il il)
        {
            if (ModelState.IsValid)
            {
                db.Entry(il).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BolgeId = new SelectList(db.Bolge, "BolgeId", "BolgeAdi", il.BolgeId);
            return View(il);
        }

        // GET: il/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            il il = db.il.Find(id);
            if (il == null)
            {
                return HttpNotFound();
            }
            return View(il);
        }

        // POST: il/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            il il = db.il.Find(id);
            db.il.Remove(il);
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
    }
}
