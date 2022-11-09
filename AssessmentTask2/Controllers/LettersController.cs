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
    public class LettersController : Controller
    {
        private AssessmentTask2Context db = new AssessmentTask2Context();

        // GET: Letters
        public ActionResult Index()
        {
            var letters = db.Letters.Include(l => l.Student);
            return View(letters.ToList());
        }

        // GET: Letters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Letter letter = db.Letters.Find(id);
            if (letter == null)
            {
                return HttpNotFound();
            }
            return View(letter);
        }

        // GET: Letters/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Firstname");
            return View();
        }

        // POST: Letters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LetterId,Paid,Beginning_Comment,Signiture,Bank,Account_Name,BSB,Account_Number,Term_Start_Date,Term_End_Date,StudentId,LessonId")] Letter letter)
        {
            if (ModelState.IsValid)
            {
                db.Letters.Add(letter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Firstname", letter.StudentId);
            return View(letter);
        }

        // GET: Letters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Letter letter = db.Letters.Find(id);
            if (letter == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Firstname", letter.StudentId);
            return View(letter);
        }

        // POST: Letters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LetterId,Paid,Beginning_Comment,Signiture,Bank,Account_Name,BSB,Account_Number,Term_Start_Date,Term_End_Date,StudentId,LessonId")] Letter letter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(letter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Firstname", letter.StudentId);
            return View(letter);
        }

        // GET: Letters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Letter letter = db.Letters.Find(id);
            if (letter == null)
            {
                return HttpNotFound();
            }
            return View(letter);
        }

        // POST: Letters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Letter letter = db.Letters.Find(id);
            db.Letters.Remove(letter);
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
