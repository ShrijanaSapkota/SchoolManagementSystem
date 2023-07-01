using DBSchoolManagementSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DBSchoolManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        SchoolManagement db = new SchoolManagement();

      
        public ActionResult Index()
        {
            Department model = new Department();
            model.DepartmentList = new List<Department>();
            model.DepartmentList = db.Department.ToList();
        
            return View(model);
        }

       

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department model)
        {
            if (ModelState.IsValid)
            {
                db.Department.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            Department model = new Department();
            model = db.Department.Find(id);
            if (model == null)
            {
                model = new Department();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Department model)
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
            Department model = db.Department.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Department model = db.Department.Find(id);
            db.Department.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department model = db.Department.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
    }
}