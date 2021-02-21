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
    public class AdayController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: Aday
        public ActionResult Index()
        {
            var aday = db.Aday.Include(a => a.Secim).Include(a => a.Uye);
            return View(aday.ToList());
        }

        // GET: Aday/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aday aday = db.Aday.Find(id);
            if (aday == null)
            {
                return HttpNotFound();
            }
            return View(aday);
        }

        // GET: Aday/Create
        public ActionResult Create()
        {
            ViewBag.SecimId = new SelectList(db.Secim, "SecimId", "Konu");
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim");
            return View();
        }

        // POST: Aday/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdayId,UyeId,SecimId,Tarih,Saat,Metin")] Aday aday)
        {
            if (ModelState.IsValid)
            {
                db.Aday.Add(aday);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SecimId = new SelectList(db.Secim, "SecimId", "Konu", aday.SecimId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", aday.UyeId);
            return View(aday);
        }

        // GET: Aday/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aday aday = db.Aday.Find(id);
            if (aday == null)
            {
                return HttpNotFound();
            }
            ViewBag.SecimId = new SelectList(db.Secim, "SecimId", "Konu", aday.SecimId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", aday.UyeId);
            return View(aday);
        }

        // POST: Aday/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdayId,UyeId,SecimId,Tarih,Saat,Metin")] Aday aday)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aday).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SecimId = new SelectList(db.Secim, "SecimId", "Konu", aday.SecimId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", aday.UyeId);
            return View(aday);
        }

        // GET: Aday/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aday aday = db.Aday.Find(id);
            if (aday == null)
            {
                return HttpNotFound();
            }
            return View(aday);
        }

        // POST: Aday/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aday aday = db.Aday.Find(id);
            db.Aday.Remove(aday);
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
