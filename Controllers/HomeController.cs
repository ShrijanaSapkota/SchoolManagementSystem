using DBSchoolManagementSystem.Models;
using DBSchoolManagementSystem.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DBSchoolManagementSystem.Controllers
{
    
    public class HomeController : Controller  
    {
        
        SchoolManagement db = new SchoolManagement();
        StudentServices _SS = new StudentServices();
        public ActionResult Index()
        {
            HomePageModel model = new HomePageModel();

            // Retrieve the count values from your data source
            model.InstructorCount = db.Instructor.Count();
            model.StudentCount = db.Student.Count();
            model.CourseCount = db.Course.Count();
            model.DepartmentCount = db.Department.Count();

            return View(model);


            

            
           
        }
        public ActionResult Create()
        {
           
            return View();
        }
       

    
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Our contact page.";

            return View();
        }
        [HttpPost]

        public ActionResult Contact(string name, string email, string message)
        {
            
            return RedirectToAction("ThankYou");
            
        }

        public ActionResult ThankYou()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Search(string searchQuery)
        {
            ViewBag.StudentList = db.Student.ToList();
            ViewBag.Instructor = db.Instructor.ToList();
            

            var Student = db.Student.Where(x => x.FullName.Contains(searchQuery)).ToList();
            var Instructor = db.Instructor.Where(x => x.FirstName.Contains(searchQuery)).ToList();
            ViewBag.Instructors = Instructor;
            ViewBag.Students = Student;

            var model = new SearchViewModel();

            
            
            return View(model);

            return RedirectToAction("Index");
        }
    }


}

