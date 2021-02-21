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
    public class UyeController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: Uye
        public ActionResult Index()
        {
            var uye = db.Uye.Include(u => u.il).Include(u => u.Mahal).Include(u => u.Ulke);
            return View(uye.ToList());
        }

        // GET: Uye/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uye.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // GET: Uye/Create
        public ActionResult Create()
        {
            ViewBag.ilId = new SelectList(db.il, "ilId", "ilAdi");
            ViewBag.MahalId = new SelectList(db.Mahal, "MahalId", "MahalAdi");
            ViewBag.UlkeId = new SelectList(db.Ulke, "UlkeId", "UlkeAdi");
            return View();
        }

        // POST: Uye/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create
            ([Bind(Include = "UyeId,MahalId,isim,Soyisim,TelefonMobil,TelefonSabit,Email,Adres,ilId,UlkeId,DogumTarihi,DogumYeri")] Uye uye)
        {
            if (ModelState.IsValid)
            {
                uye.UyeId = Guid.NewGuid();
                db.Uye.Add(uye);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ilId = new SelectList(db.il, "ilId", "ilAdi", uye.ilId);
            ViewBag.MahalId = new SelectList(db.Mahal, "MahalId", "MahalAdi", uye.MahalId);
            ViewBag.UlkeId = new SelectList(db.Ulke, "UlkeId", "UlkeAdi", uye.UlkeId);
            return View(uye);
        }

        // GET: Uye/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uye.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            ViewBag.ilId = new SelectList(db.il, "ilId", "ilAdi", uye.ilId);
            ViewBag.MahalId = new SelectList(db.Mahal, "MahalId", "MahalAdi", uye.MahalId);
            ViewBag.UlkeId = new SelectList(db.Ulke, "UlkeId", "UlkeAdi", uye.UlkeId);
            return View(uye);
        }

        // POST: Uye/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UyeId,MahalId,isim,Soyisim,TelefonMobil,TelefonSabit,Email,Adres,ilId,UlkeId,DogumTarihi,DogumYeri")] Uye uye)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ilId = new SelectList(db.il, "ilId", "ilAdi", uye.ilId);
            ViewBag.MahalId = new SelectList(db.Mahal, "MahalId", "MahalAdi", uye.MahalId);
            ViewBag.UlkeId = new SelectList(db.Ulke, "UlkeId", "UlkeAdi", uye.UlkeId);
            return View(uye);
        }

        // GET: Uye/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uye uye = db.Uye.Find(id);
            if (uye == null)
            {
                return HttpNotFound();
            }
            return View(uye);
        }

        // POST: Uye/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Uye uye = db.Uye.Find(id);
            db.Uye.Remove(uye);
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
