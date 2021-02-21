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
    public class AdayOyController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: AdayOy
        public ActionResult Index()
        {
            var adayOy = db.AdayOy.Include(a => a.Aday).Include(a => a.OyTuru).Include(a => a.Uye);
            return View(adayOy.ToList());
        }

        // GET: AdayOy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdayOy adayOy = db.AdayOy.Find(id);
            if (adayOy == null)
            {
                return HttpNotFound();
            }
            return View(adayOy);
        }

        // GET: AdayOy/Create
        public ActionResult Create()
        {
            ViewBag.AdayId = new SelectList(db.Aday, "AdayId", "Metin");
            ViewBag.OyTuruId = new SelectList(db.OyTuru, "OyTuruId", "OyTuruAdi");
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim");
            return View();
        }

        // POST: AdayOy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdayOyId,AdayId,UyeId,OyTuruId,Tarih,Saat")] AdayOy adayOy)
        {
            if (ModelState.IsValid)
            {
                db.AdayOy.Add(adayOy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdayId = new SelectList(db.Aday, "AdayId", "Metin", adayOy.AdayId);
            ViewBag.OyTuruId = new SelectList(db.OyTuru, "OyTuruId", "OyTuruAdi", adayOy.OyTuruId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", adayOy.UyeId);
            return View(adayOy);
        }

        // GET: AdayOy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdayOy adayOy = db.AdayOy.Find(id);
            if (adayOy == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdayId = new SelectList(db.Aday, "AdayId", "Metin", adayOy.AdayId);
            ViewBag.OyTuruId = new SelectList(db.OyTuru, "OyTuruId", "OyTuruAdi", adayOy.OyTuruId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", adayOy.UyeId);
            return View(adayOy);
        }

        // POST: AdayOy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdayOyId,AdayId,UyeId,OyTuruId,Tarih,Saat")] AdayOy adayOy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adayOy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdayId = new SelectList(db.Aday, "AdayId", "Metin", adayOy.AdayId);
            ViewBag.OyTuruId = new SelectList(db.OyTuru, "OyTuruId", "OyTuruAdi", adayOy.OyTuruId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", adayOy.UyeId);
            return View(adayOy);
        }

        // GET: AdayOy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdayOy adayOy = db.AdayOy.Find(id);
            if (adayOy == null)
            {
                return HttpNotFound();
            }
            return View(adayOy);
        }

        // POST: AdayOy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdayOy adayOy = db.AdayOy.Find(id);
            db.AdayOy.Remove(adayOy);
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
