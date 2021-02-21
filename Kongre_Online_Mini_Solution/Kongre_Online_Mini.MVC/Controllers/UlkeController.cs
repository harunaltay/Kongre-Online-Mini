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
    public class UlkeController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: Ulke
        public ActionResult Index()
        {
            return View(db.Ulke.ToList());
        }

        // GET: Ulke/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ulke ulke = db.Ulke.Find(id);
            if (ulke == null)
            {
                return HttpNotFound();
            }
            return View(ulke);
        }

        // GET: Ulke/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ulke/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UlkeId,UlkeAdi")] Ulke ulke)
        {
            if (ModelState.IsValid)
            {
                db.Ulke.Add(ulke);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ulke);
        }

        // GET: Ulke/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ulke ulke = db.Ulke.Find(id);
            if (ulke == null)
            {
                return HttpNotFound();
            }
            return View(ulke);
        }

        // POST: Ulke/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UlkeId,UlkeAdi")] Ulke ulke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ulke).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ulke);
        }

        // GET: Ulke/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ulke ulke = db.Ulke.Find(id);
            if (ulke == null)
            {
                return HttpNotFound();
            }
            return View(ulke);
        }

        // POST: Ulke/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ulke ulke = db.Ulke.Find(id);
            db.Ulke.Remove(ulke);
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
