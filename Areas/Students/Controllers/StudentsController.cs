using DBSchoolManagementSystem.Controllers;
using DBSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBSchoolManagementSystem.Areas.Students.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students/Students
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student model)
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                if (db.Student.Any(x => x.FullName == model.FullName))
                {
                    ModelState.AddModelError("FullName", "Name Already Exist");
                }
                if (ModelState.IsValid)
                {
                    db.Student.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}