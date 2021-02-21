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
    public class AdayYorumController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: AdayYorum
        public ActionResult Index()
        {
            var adayYorum = db.AdayYorum.Include(a => a.Aday).Include(a => a.Uye).Include(a => a.YorumTuru);
            return View(adayYorum.ToList());
        }

        // GET: AdayYorum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdayYorum adayYorum = db.AdayYorum.Find(id);
            if (adayYorum == null)
            {
                return HttpNotFound();
            }
            return View(adayYorum);
        }

        // GET: AdayYorum/Create
        public ActionResult Create()
        {
            ViewBag.AdayId = new SelectList(db.Aday, "AdayId", "Metin");
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim");
            ViewBag.YorumTuruId = new SelectList(db.YorumTuru, "YorumTuruId", "YorumTuruAdi");
            return View();
        }

        // POST: AdayYorum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdayYorumId,AdayId,UyeId,Tarih,Saat,YorumTuruId,Metin")] AdayYorum adayYorum)
        {
            if (ModelState.IsValid)
            {
                db.AdayYorum.Add(adayYorum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdayId = new SelectList(db.Aday, "AdayId", "Metin", adayYorum.AdayId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", adayYorum.UyeId);
            ViewBag.YorumTuruId = new SelectList(db.YorumTuru, "YorumTuruId", "YorumTuruAdi", adayYorum.YorumTuruId);
            return View(adayYorum);
        }

        // GET: AdayYorum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdayYorum adayYorum = db.AdayYorum.Find(id);
            if (adayYorum == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdayId = new SelectList(db.Aday, "AdayId", "Metin", adayYorum.AdayId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", adayYorum.UyeId);
            ViewBag.YorumTuruId = new SelectList(db.YorumTuru, "YorumTuruId", "YorumTuruAdi", adayYorum.YorumTuruId);
            return View(adayYorum);
        }

        // POST: AdayYorum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdayYorumId,AdayId,UyeId,Tarih,Saat,YorumTuruId,Metin")] AdayYorum adayYorum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adayYorum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdayId = new SelectList(db.Aday, "AdayId", "Metin", adayYorum.AdayId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", adayYorum.UyeId);
            ViewBag.YorumTuruId = new SelectList(db.YorumTuru, "YorumTuruId", "YorumTuruAdi", adayYorum.YorumTuruId);
            return View(adayYorum);
        }

        // GET: AdayYorum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdayYorum adayYorum = db.AdayYorum.Find(id);
            if (adayYorum == null)
            {
                return HttpNotFound();
            }
            return View(adayYorum);
        }

        // POST: AdayYorum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdayYorum adayYorum = db.AdayYorum.Find(id);
            db.AdayYorum.Remove(adayYorum);
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
