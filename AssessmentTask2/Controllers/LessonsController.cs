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
    public class LessonsController : Controller
    {
        private AssessmentTask2Context db = new AssessmentTask2Context();

        // GET: Lessons
        public ActionResult Index(string option, string search)
        {
            if (option == "Instrument")
            {
                return View(db.Lessons.Where(x => x.Instrument.InstrumentName == search || search == null).ToList());
            }
            else if (option == "Tutor")
            {
                return View(db.Lessons.Where(x => x.Tutor.TutorName == search || search == null).ToList());

            }
            else if (option == "Term")
            {
                return View(db.Lessons.Where(x => x.Letter.Current_Term.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(db.Lessons.Where(x => x.Student.Firstname.StartsWith(search) || search == null).ToList());
            }
        }

        public ActionResult CreateLetter(int[] Selected)
        {
            ViewBag.LessonId = new SelectList(db.Lessons, "LessonId", "LessonId");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "FirstName");
            return View();

        }

        // GET: Lessons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // GET: Lessons/Create
        public ActionResult Create()
        {
            ViewBag.DurationId = new SelectList(db.Durations, "DurationId", "TimeTaken");
            ViewBag.InstrumentId = new SelectList(db.Instruments, "InstrumentId", "InstrumentName");
            ViewBag.LetterId = new SelectList(db.Letters, "LetterId", "LetterId");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Firstname");
            ViewBag.TutorId = new SelectList(db.Tutors, "TutorId", "TutorName");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LessonId,StudentId,InstrumentId,TutorId,LessonDate,LessonTime,DurationId,LetterId")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Lessons.Add(lesson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DurationId = new SelectList(db.Durations, "DurationId", "TimeTaken", lesson.DurationId);
            ViewBag.InstrumentId = new SelectList(db.Instruments, "InstrumentId", "InstrumentName", lesson.InstrumentId);
            ViewBag.LetterId = new SelectList(db.Letters, "LetterId", "LetterId", lesson.LetterId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Firstname", lesson.StudentId);
            ViewBag.TutorId = new SelectList(db.Tutors, "TutorId", "TutorName", lesson.TutorId);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.DurationId = new SelectList(db.Durations, "DurationId", "TimeTaken", lesson.DurationId);
            ViewBag.InstrumentId = new SelectList(db.Instruments, "InstrumentId", "InstrumentName", lesson.InstrumentId);
            ViewBag.LetterId = new SelectList(db.Letters, "LetterId", "LetterId", lesson.LetterId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Firstname", lesson.StudentId);
            ViewBag.TutorId = new SelectList(db.Tutors, "TutorId", "TutorName", lesson.TutorId);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LessonId,StudentId,InstrumentId,TutorId,LessonDate,LessonTime,DurationId,LetterId")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lesson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DurationId = new SelectList(db.Durations, "DurationId", "TimeTaken", lesson.DurationId);
            ViewBag.InstrumentId = new SelectList(db.Instruments, "InstrumentId", "InstrumentName", lesson.InstrumentId);
            ViewBag.LetterId = new SelectList(db.Letters, "LetterId", "LetterId", lesson.LetterId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Firstname", lesson.StudentId);
            ViewBag.TutorId = new SelectList(db.Tutors, "TutorId", "TutorName", lesson.TutorId);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lesson lesson = db.Lessons.Find(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }
            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lesson lesson = db.Lessons.Find(id);
            db.Lessons.Remove(lesson);
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
