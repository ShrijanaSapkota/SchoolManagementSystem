using DBSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DBSchoolManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
            SchoolManagement db = new SchoolManagement();
        
        public ActionResult Index()
            {
                Course model = new Course();
                model.CourseList = new List<Course>();
                model.CourseList = db.Course.ToList();
                return View(model);
            }



            public ActionResult Create()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Course model)
            {
                if (ModelState.IsValid)
                {
                    db.Course.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            public ActionResult Edit(int id)
            {
                Course model = new Course();
                model = db.Course.Find(id);
                if (model == null)
                {
                    model = new Course();
                }
                return View(model);
            }
            [HttpPost]
            public ActionResult Edit(Course model)
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
                Course model = db.Course.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View(model);
            }
            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                Course model = db.Course.Find(id);
                db.Course.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Course model = db.Course.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View(model);
            }
        }
}