using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBSchoolManagementSystem.Areas.Instructors.Controllers
{
    public class InstructorsController : Controller
    {
        // GET: Instructors/Instructors
        public ActionResult Index()
        {
            return View();
        }
    }
}