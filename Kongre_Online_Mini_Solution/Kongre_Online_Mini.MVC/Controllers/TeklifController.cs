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
    public class TeklifController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: Teklif
        public ActionResult Index()
        {
            var teklif = db.Teklif.Include(t => t.Oturum).Include(t => t.Uye);
            return View(teklif.ToList());
        }

        // GET: Teklif/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teklif teklif = db.Teklif.Find(id);
            if (teklif == null)
            {
                return HttpNotFound();
            }
            return View(teklif);
        }

        // GET: Teklif/Create
        public ActionResult Create()
        {
            ViewBag.OturumId = new SelectList(db.Oturum, "OturumId", "Konu");
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim");
            return View();
        }

        // POST: Teklif/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeklifId,UyeId,OturumId,Tarih,Saat,Metin")] Teklif teklif)
        {
            if (ModelState.IsValid)
            {
                db.Teklif.Add(teklif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OturumId = new SelectList(db.Oturum, "OturumId", "Konu", teklif.OturumId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", teklif.UyeId);
            return View(teklif);
        }

        // GET: Teklif/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teklif teklif = db.Teklif.Find(id);
            if (teklif == null)
            {
                return HttpNotFound();
            }
            ViewBag.OturumId = new SelectList(db.Oturum, "OturumId", "Konu", teklif.OturumId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", teklif.UyeId);
            return View(teklif);
        }

        // POST: Teklif/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeklifId,UyeId,OturumId,Tarih,Saat,Metin")] Teklif teklif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teklif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OturumId = new SelectList(db.Oturum, "OturumId", "Konu", teklif.OturumId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", teklif.UyeId);
            return View(teklif);
        }

        // GET: Teklif/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teklif teklif = db.Teklif.Find(id);
            if (teklif == null)
            {
                return HttpNotFound();
            }
            return View(teklif);
        }

        // POST: Teklif/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teklif teklif = db.Teklif.Find(id);
            db.Teklif.Remove(teklif);
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
