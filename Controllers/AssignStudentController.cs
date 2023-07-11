using DBSchoolManagementSystem.Models;
using DBSchoolManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBSchoolManagementSystem.Controllers
{
    public class AssignStudentController : Controller

    {
        SchoolManagement db = new SchoolManagement();
        StudentServices _SS = new StudentServices();
        // GET: AssignStudent
        public ActionResult Index()
        {
            var assignstudent = _SS.GetAssignStudentList();
            return View(assignstudent);
            return View();
        }
        public ActionResult create()
        {

            ViewBag.StudentList = db.Student.ToList();
            ViewBag.SemesterList = db.Semester.ToList();
            ViewBag.DepartmentList = db.Department.ToList();

            return View();

        }
        [HttpPost]

        public ActionResult create(AssignStudent model)
        {

            if (ModelState.IsValid)
            {
                db.AssignStudent.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}