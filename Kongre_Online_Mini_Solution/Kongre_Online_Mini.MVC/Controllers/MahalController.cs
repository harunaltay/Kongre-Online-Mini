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
    public class MahalController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: Mahal
        public ActionResult Index()
        {
            var mahal = db.Mahal.Include(m => m.Bolge).Include(m => m.il);
            return View(mahal.ToList());
        }

        // GET: Mahal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahal mahal = db.Mahal.Find(id);
            if (mahal == null)
            {
                return HttpNotFound();
            }
            return View(mahal);
        }

        // GET: Mahal/Create
        public ActionResult Create()
        {
            ViewBag.BolgeId = new SelectList(db.Bolge, "BolgeId", "BolgeAdi");
            ViewBag.ilId = new SelectList(db.il, "ilId", "ilAdi");
            return View();
        }

        // POST: Mahal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MahalId,MahalAdi,ilId,BolgeId")] Mahal mahal)
        {
            if (ModelState.IsValid)
            {
                db.Mahal.Add(mahal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BolgeId = new SelectList(db.Bolge, "BolgeId", "BolgeAdi", mahal.BolgeId);
            ViewBag.ilId = new SelectList(db.il, "ilId", "ilAdi", mahal.ilId);
            return View(mahal);
        }

        // GET: Mahal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahal mahal = db.Mahal.Find(id);
            if (mahal == null)
            {
                return HttpNotFound();
            }
            ViewBag.BolgeId = new SelectList(db.Bolge, "BolgeId", "BolgeAdi", mahal.BolgeId);
            ViewBag.ilId = new SelectList(db.il, "ilId", "ilAdi", mahal.ilId);
            return View(mahal);
        }

        // POST: Mahal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MahalId,MahalAdi,ilId,BolgeId")] Mahal mahal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mahal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BolgeId = new SelectList(db.Bolge, "BolgeId", "BolgeAdi", mahal.BolgeId);
            ViewBag.ilId = new SelectList(db.il, "ilId", "ilAdi", mahal.ilId);
            return View(mahal);
        }

        // GET: Mahal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahal mahal = db.Mahal.Find(id);
            if (mahal == null)
            {
                return HttpNotFound();
            }
            return View(mahal);
        }

        // POST: Mahal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mahal mahal = db.Mahal.Find(id);
            db.Mahal.Remove(mahal);
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
