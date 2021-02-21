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
    public class YorumTuruController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: YorumTuru
        public ActionResult Index()
        {
            return View(db.YorumTuru.ToList());
        }

        // GET: YorumTuru/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YorumTuru yorumTuru = db.YorumTuru.Find(id);
            if (yorumTuru == null)
            {
                return HttpNotFound();
            }
            return View(yorumTuru);
        }

        // GET: YorumTuru/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YorumTuru/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YorumTuruId,YorumTuruAdi")] YorumTuru yorumTuru)
        {
            if (ModelState.IsValid)
            {
                db.YorumTuru.Add(yorumTuru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yorumTuru);
        }

        // GET: YorumTuru/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YorumTuru yorumTuru = db.YorumTuru.Find(id);
            if (yorumTuru == null)
            {
                return HttpNotFound();
            }
            return View(yorumTuru);
        }

        // POST: YorumTuru/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YorumTuruId,YorumTuruAdi")] YorumTuru yorumTuru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yorumTuru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yorumTuru);
        }

        // GET: YorumTuru/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YorumTuru yorumTuru = db.YorumTuru.Find(id);
            if (yorumTuru == null)
            {
                return HttpNotFound();
            }
            return View(yorumTuru);
        }

        // POST: YorumTuru/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YorumTuru yorumTuru = db.YorumTuru.Find(id);
            db.YorumTuru.Remove(yorumTuru);
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
