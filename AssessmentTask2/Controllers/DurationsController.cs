﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssessmentTask2.Data;
using AssessmentTask2.Models;

namespace AssessmentTask2.Controllers
{
    public class DurationsController : Controller
    {
        private AssessmentTask2Context db = new AssessmentTask2Context();

        // GET: Durations
        public ActionResult Index()
        {
            return View(db.Durations.ToList());
        }

        // GET: Durations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duration duration = db.Durations.Find(id);
            if (duration == null)
            {
                return HttpNotFound();
            }
            return View(duration);
        }

        // GET: Durations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Durations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DurationId,TimeTaken,Cost")] Duration duration)
        {
            if (ModelState.IsValid)
            {
                db.Durations.Add(duration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(duration);
        }

        // GET: Durations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duration duration = db.Durations.Find(id);
            if (duration == null)
            {
                return HttpNotFound();
            }
            return View(duration);
        }

        // POST: Durations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DurationId,TimeTaken,Cost")] Duration duration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(duration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(duration);
        }

        // GET: Durations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duration duration = db.Durations.Find(id);
            if (duration == null)
            {
                return HttpNotFound();
            }
            return View(duration);
        }

        // POST: Durations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Duration duration = db.Durations.Find(id);
            db.Durations.Remove(duration);
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
