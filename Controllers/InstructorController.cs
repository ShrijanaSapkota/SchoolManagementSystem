using DBSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static DBSchoolManagementSystem.Models.Instructor;


namespace DBSchoolManagementSystem.Controllers
{

    public class InstructorController : Controller
    {
        SchoolManagement db = new SchoolManagement();

        public ActionResult Index()
        {
            Instructor model = new Instructor();
            model.InstructorList = new List<Instructor>();
            model.InstructorList = db.Instructor.ToList();

            return View(model);
        }
        public ActionResult AddItem()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instructor model)
        {
            if (ModelState.IsValid)
            {
                db.Instructor.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            Instructor model = new Instructor();
            model = db.Instructor.Find(id);
            if (model == null)
            {
                model = new Instructor();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Instructor model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor model = db.Instructor.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Instructor model = db.Instructor.Find(id);
            db.Instructor.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor model = db.Instructor.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult ViewLeaveNotes()
        {
            // Retrieve all leave notes from the database
            var leaveNotes = db.LeaveNotes.ToList();

            return View(leaveNotes);
        }
    }

    }
