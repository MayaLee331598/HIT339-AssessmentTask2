using System;
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
    public class TutorsController : Controller
    {
        private AssessmentTask2Context db = new AssessmentTask2Context();

        // GET: Tutors
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            var tutor = from s in db.Tutors
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                tutor = tutor.Where(s => s.TutorName.ToUpper().Contains(searchString.ToUpper())
                                       || s.TutorName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    tutor = tutor.OrderByDescending(s => s.TutorName);
                    break;
                case "Date":
                    tutor = tutor.OrderBy(s => s.TutorId);
                    break;
                case "Date_desc":
                    tutor = tutor.OrderByDescending(s => s.TutorId);
                    break;
                default:
                    tutor = tutor.OrderBy(s => s.TutorName);
                    break;
            }
            return View(tutor.ToList());
        }

        // GET: Tutors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // GET: Tutors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TutorId,TutorName")] Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                db.Tutors.Add(tutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tutor);
        }

        // GET: Tutors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // POST: Tutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TutorId,TutorName")] Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tutor);
        }

        // GET: Tutors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // POST: Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tutor tutor = db.Tutors.Find(id);
            db.Tutors.Remove(tutor);
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
