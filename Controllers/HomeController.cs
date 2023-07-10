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
        public ActionResult Index()
        {
            return View();
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

       



    }
}
