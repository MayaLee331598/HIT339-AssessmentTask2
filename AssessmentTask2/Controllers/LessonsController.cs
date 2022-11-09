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
        public ActionResult Index()
        {
            var lessons = db.Lessons.Include(l => l.Duration).Include(l => l.Instrument).Include(l => l.Student).Include(l => l.Tutor);
            return View(lessons.ToList());
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
            ViewBag.DurationId = new SelectList(db.Durations, "DurationId", "DurationId");
            ViewBag.InstrumentId = new SelectList(db.Instruments, "InstrumentId", "InstrumentName");
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

            ViewBag.DurationId = new SelectList(db.Durations, "DurationId", "DurationId", lesson.DurationId);
            ViewBag.InstrumentId = new SelectList(db.Instruments, "InstrumentId", "InstrumentName", lesson.InstrumentId);
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
            ViewBag.DurationId = new SelectList(db.Durations, "DurationId", "DurationId", lesson.DurationId);
            ViewBag.InstrumentId = new SelectList(db.Instruments, "InstrumentId", "InstrumentName", lesson.InstrumentId);
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
            ViewBag.DurationId = new SelectList(db.Durations, "DurationId", "DurationId", lesson.DurationId);
            ViewBag.InstrumentId = new SelectList(db.Instruments, "InstrumentId", "InstrumentName", lesson.InstrumentId);
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
