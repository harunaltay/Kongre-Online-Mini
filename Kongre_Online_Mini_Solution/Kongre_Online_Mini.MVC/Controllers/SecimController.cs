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
    public class SecimController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: Secim
        public ActionResult Index()
        {
            var secim = db.Secim.Include(s => s.Mahal).Include(s => s.Oturum);
            return View(secim.ToList());
        }

        // GET: Secim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secim secim = db.Secim.Find(id);
            if (secim == null)
            {
                return HttpNotFound();
            }
            return View(secim);
        }

        // GET: Secim/Create
        public ActionResult Create()
        {
            ViewBag.MahalId = new SelectList(db.Mahal, "MahalId", "MahalAdi");
            ViewBag.OturumId = new SelectList(db.Oturum, "OturumId", "Konu");
            return View();
        }

        // POST: Secim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SecimId,MahalId,OturumId,Tarih,Saat,Konu,Metin")] Secim secim)
        {
            if (ModelState.IsValid)
            {
                db.Secim.Add(secim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MahalId = new SelectList(db.Mahal, "MahalId", "MahalAdi", secim.MahalId);
            ViewBag.OturumId = new SelectList(db.Oturum, "OturumId", "Konu", secim.OturumId);
            return View(secim);
        }

        // GET: Secim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secim secim = db.Secim.Find(id);
            if (secim == null)
            {
                return HttpNotFound();
            }
            ViewBag.MahalId = new SelectList(db.Mahal, "MahalId", "MahalAdi", secim.MahalId);
            ViewBag.OturumId = new SelectList(db.Oturum, "OturumId", "Konu", secim.OturumId);
            return View(secim);
        }

        // POST: Secim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SecimId,MahalId,OturumId,Tarih,Saat,Konu,Metin")] Secim secim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MahalId = new SelectList(db.Mahal, "MahalId", "MahalAdi", secim.MahalId);
            ViewBag.OturumId = new SelectList(db.Oturum, "OturumId", "Konu", secim.OturumId);
            return View(secim);
        }

        // GET: Secim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Secim secim = db.Secim.Find(id);
            if (secim == null)
            {
                return HttpNotFound();
            }
            return View(secim);
        }

        // POST: Secim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Secim secim = db.Secim.Find(id);
            db.Secim.Remove(secim);
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
