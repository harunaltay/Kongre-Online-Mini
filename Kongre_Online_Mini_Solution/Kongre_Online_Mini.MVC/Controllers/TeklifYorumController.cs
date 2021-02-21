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
    public class TeklifYorumController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: TeklifYorum
        public ActionResult Index()
        {
            var teklifYorum = db.TeklifYorum.Include(t => t.Teklif).Include(t => t.Uye).Include(t => t.YorumTuru);
            return View(teklifYorum.ToList());
        }

        // GET: TeklifYorum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeklifYorum teklifYorum = db.TeklifYorum.Find(id);
            if (teklifYorum == null)
            {
                return HttpNotFound();
            }
            return View(teklifYorum);
        }

        // GET: TeklifYorum/Create
        public ActionResult Create()
        {
            ViewBag.TeklifId = new SelectList(db.Teklif, "TeklifId", "Metin");
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim");
            ViewBag.YorumTuruId = new SelectList(db.YorumTuru, "YorumTuruId", "YorumTuruAdi");
            return View();
        }

        // POST: TeklifYorum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeklifYorumId,TeklifId,UyeId,Tarih,Saat,YorumTuruId,Metin")] TeklifYorum teklifYorum)
        {
            if (ModelState.IsValid)
            {
                db.TeklifYorum.Add(teklifYorum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeklifId = new SelectList(db.Teklif, "TeklifId", "Metin", teklifYorum.TeklifId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", teklifYorum.UyeId);
            ViewBag.YorumTuruId = new SelectList(db.YorumTuru, "YorumTuruId", "YorumTuruAdi", teklifYorum.YorumTuruId);
            return View(teklifYorum);
        }

        // GET: TeklifYorum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeklifYorum teklifYorum = db.TeklifYorum.Find(id);
            if (teklifYorum == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeklifId = new SelectList(db.Teklif, "TeklifId", "Metin", teklifYorum.TeklifId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", teklifYorum.UyeId);
            ViewBag.YorumTuruId = new SelectList(db.YorumTuru, "YorumTuruId", "YorumTuruAdi", teklifYorum.YorumTuruId);
            return View(teklifYorum);
        }

        // POST: TeklifYorum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeklifYorumId,TeklifId,UyeId,Tarih,Saat,YorumTuruId,Metin")] TeklifYorum teklifYorum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teklifYorum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeklifId = new SelectList(db.Teklif, "TeklifId", "Metin", teklifYorum.TeklifId);
            ViewBag.UyeId = new SelectList(db.Uye, "UyeId", "isim", teklifYorum.UyeId);
            ViewBag.YorumTuruId = new SelectList(db.YorumTuru, "YorumTuruId", "YorumTuruAdi", teklifYorum.YorumTuruId);
            return View(teklifYorum);
        }

        // GET: TeklifYorum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeklifYorum teklifYorum = db.TeklifYorum.Find(id);
            if (teklifYorum == null)
            {
                return HttpNotFound();
            }
            return View(teklifYorum);
        }

        // POST: TeklifYorum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeklifYorum teklifYorum = db.TeklifYorum.Find(id);
            db.TeklifYorum.Remove(teklifYorum);
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
