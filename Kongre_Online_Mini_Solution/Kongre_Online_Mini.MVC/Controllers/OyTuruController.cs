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
    public class OyTuruController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: OyTuru
        public ActionResult Index()
        {
            return View(db.OyTuru.ToList());
        }

        // GET: OyTuru/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OyTuru oyTuru = db.OyTuru.Find(id);
            if (oyTuru == null)
            {
                return HttpNotFound();
            }
            return View(oyTuru);
        }

        // GET: OyTuru/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OyTuru/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OyTuruId,OyTuruAdi")] OyTuru oyTuru)
        {
            if (ModelState.IsValid)
            {
                db.OyTuru.Add(oyTuru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oyTuru);
        }

        // GET: OyTuru/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OyTuru oyTuru = db.OyTuru.Find(id);
            if (oyTuru == null)
            {
                return HttpNotFound();
            }
            return View(oyTuru);
        }

        // POST: OyTuru/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OyTuruId,OyTuruAdi")] OyTuru oyTuru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oyTuru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oyTuru);
        }

        // GET: OyTuru/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OyTuru oyTuru = db.OyTuru.Find(id);
            if (oyTuru == null)
            {
                return HttpNotFound();
            }
            return View(oyTuru);
        }

        // POST: OyTuru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OyTuru oyTuru = db.OyTuru.Find(id);
            db.OyTuru.Remove(oyTuru);
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
