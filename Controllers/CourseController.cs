using DBSchoolManagementSystem.Models;
using DBSchoolManagementSystem.Services;
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
        StudentServices _SS=new StudentServices();
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
            Semester semester = new Semester();
            semester.SemesterList = new List<Semester>();
            ViewBag.SemesterList = db.Semester.ToList();

            Department department = new Department();
            department.DepartmentList = new List<Department>();
            ViewBag.DepartmentList = db.Department.ToList();
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
        public ActionResult AssignInstructor()
        {
            Instructor model = new Instructor();
            model.InstructorList = new List<Instructor>();
            ViewBag.InstructorList = db.Instructor.ToList();

            Course course = new Course();
            course.CourseList = new List<Course>();
            ViewBag.CourseList = db.Course.ToList();

            Department department= new Department();
            department.DepartmentList = new List<Department>();
            ViewBag.DepartmentList = db.Department.ToList();

            return View();

        }
        [HttpPost]

        public ActionResult AssignInstructor(AssignInstructorVm a)
        {
            if (a == null)
            {
                return View();
            }


            if (ModelState.IsValid)
            {
                var assigninstructor = new AssignInstructor();
                assigninstructor.Instructorid = a.Instructorid;
                assigninstructor.DepartmentId = a.DepartmentId;
                assigninstructor.Courseid = a.Courseid;
                db.AssignInstructor.Add(assigninstructor);
                db.SaveChanges();
                return RedirectToAction("AssignIndex");
            }

            return View();
        }
        public ActionResult AssignIndex()

        {
            var assigninstructor = _SS.GetAssignInstructorList();
            if (assigninstructor != null)
            {
                return View(assigninstructor);
            }

         
            return View(assigninstructor);

        }

        [HttpGet]
        [Route("get/CourseunderDepartment")]
        public JsonResult CourseunderDepartment(int departmentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Course> courseList = db.Course.Where(x => x.DepartmentId == departmentId).ToList();

            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //[Route("get/CourseunderDepartment")]
        //public JsonResult CourseunderDepartment(int Courseid)
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //    List<Course>CourseList =db.Course.Where(x => x.Courseid == Courseid).ToList();

        //    return Json(CourseList,JsonRequestBehavior.AllowGet);
        //}
    }    
}