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
    public class TeklifOyController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: TeklifOy
        public ActionResult Index()
        {
            var teklifOy = db.TeklifOy.Include(t => t.OyTuru).Include(t => t.Teklif).Include(t => t.Uye);
            return View(teklifOy.ToList());
        }

        // GET: TeklifOy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeklifOy teklifOy = db.TeklifOy.Find(id);
            if (teklifOy == null)
            {
                return HttpNotFound();
            }
            return View(teklifOy);
        }

        // GET: TeklifOy/Create
        public ActionResult Create()
        {
            ViewBag.OyTuruId = new SelectList(db.OyTuru, "OyTuruId", "OyTuruAdi");
            ViewBag.TeklifId = new SelectList(db.Teklif, "TeklifId", "Metin");
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim");
            return View();
        }

        // POST: TeklifOy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeklifOyId,TeklifId,UyeId,OyTuruId,Tarih,Saat")] TeklifOy teklifOy)
        {
            if (ModelState.IsValid)
            {
                db.TeklifOy.Add(teklifOy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OyTuruId = new SelectList(db.OyTuru, "OyTuruId", "OyTuruAdi", teklifOy.OyTuruId);
            ViewBag.TeklifId = new SelectList(db.Teklif, "TeklifId", "Metin", teklifOy.TeklifId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", teklifOy.UyeId);
            return View(teklifOy);
        }

        // GET: TeklifOy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeklifOy teklifOy = db.TeklifOy.Find(id);
            if (teklifOy == null)
            {
                return HttpNotFound();
            }
            ViewBag.OyTuruId = new SelectList(db.OyTuru, "OyTuruId", "OyTuruAdi", teklifOy.OyTuruId);
            ViewBag.TeklifId = new SelectList(db.Teklif, "TeklifId", "Metin", teklifOy.TeklifId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", teklifOy.UyeId);
            return View(teklifOy);
        }

        // POST: TeklifOy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeklifOyId,TeklifId,UyeId,OyTuruId,Tarih,Saat")] TeklifOy teklifOy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teklifOy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OyTuruId = new SelectList(db.OyTuru, "OyTuruId", "OyTuruAdi", teklifOy.OyTuruId);
            ViewBag.TeklifId = new SelectList(db.Teklif, "TeklifId", "Metin", teklifOy.TeklifId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", teklifOy.UyeId);
            return View(teklifOy);
        }

        // GET: TeklifOy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeklifOy teklifOy = db.TeklifOy.Find(id);
            if (teklifOy == null)
            {
                return HttpNotFound();
            }
            return View(teklifOy);
        }

        // POST: TeklifOy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeklifOy teklifOy = db.TeklifOy.Find(id);
            db.TeklifOy.Remove(teklifOy);
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
