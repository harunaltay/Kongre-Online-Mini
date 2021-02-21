﻿using System;
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
    public class BolgeController : Controller
    {
        private KongreOnlineMiniDBEntities db = new KongreOnlineMiniDBEntities();

        // GET: Bolge
        public ActionResult Index()
        {
            return View(db.Bolge.ToList());
        }

        // GET: Bolge/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolge bolge = db.Bolge.Find(id);
            if (bolge == null)
            {
                return HttpNotFound();
            }
            return View(bolge);
        }

        // GET: Bolge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bolge/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BolgeId,BolgeAdi")] Bolge bolge)
        {
            if (ModelState.IsValid)
            {
                db.Bolge.Add(bolge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bolge);
        }

        // GET: Bolge/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolge bolge = db.Bolge.Find(id);
            if (bolge == null)
            {
                return HttpNotFound();
            }
            return View(bolge);
        }

        // POST: Bolge/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BolgeId,BolgeAdi")] Bolge bolge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bolge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bolge);
        }

        // GET: Bolge/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolge bolge = db.Bolge.Find(id);
            if (bolge == null)
            {
                return HttpNotFound();
            }
            return View(bolge);
        }

        // POST: Bolge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bolge bolge = db.Bolge.Find(id);
            db.Bolge.Remove(bolge);
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
