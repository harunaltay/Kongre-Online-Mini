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
    public class OturumController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: Oturum
        public ActionResult Index()
        {
            var oturum = db.Oturum.Include(o => o.Mahal);
            return View(oturum.ToList());
        }

        // GET: Oturum/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oturum oturum = db.Oturum.Find(id);
            if (oturum == null)
            {
                return HttpNotFound();
            }
            return View(oturum);
        }

        // GET: Oturum/Create
        public ActionResult Create()
        {
            ViewBag.MahalId = new SelectList(db.Mahal, "MahalId", "MahalAdi");
            return View();
        }

        // POST: Oturum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OturumId,MahalId,Tarih,Saat,Konu,Metin")] Oturum oturum)
        {
            if (ModelState.IsValid)
            {
                db.Oturum.Add(oturum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MahalId = new SelectList(db.Mahal, "MahalId", "MahalAdi", oturum.MahalId);
            return View(oturum);
        }

        // GET: Oturum/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oturum oturum = db.Oturum.Find(id);
            if (oturum == null)
            {
                return HttpNotFound();
            }
            ViewBag.MahalId = new SelectList(db.Mahal, "MahalId", "MahalAdi", oturum.MahalId);
            return View(oturum);
        }

        // POST: Oturum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OturumId,MahalId,Tarih,Saat,Konu,Metin")] Oturum oturum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oturum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MahalId = new SelectList(db.Mahal, "MahalId", "MahalAdi", oturum.MahalId);
            return View(oturum);
        }

        // GET: Oturum/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oturum oturum = db.Oturum.Find(id);
            if (oturum == null)
            {
                return HttpNotFound();
            }
            return View(oturum);
        }

        // POST: Oturum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oturum oturum = db.Oturum.Find(id);
            db.Oturum.Remove(oturum);
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
