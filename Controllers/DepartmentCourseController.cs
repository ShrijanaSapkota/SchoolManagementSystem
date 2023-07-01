using DBSchoolManagementSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBSchoolManagementSystem.Controllers
{
    public class DepartmentCourseController : Controller
    {
        SchoolManagement db = new SchoolManagement();
        // GET: DepartmentCourse
        public ActionResult Index()
        {
            ViewBag.DepartmentList=new SelectList(GetDepartmentList(),"DepartmentId", "DepartmentName");
            return View();
        }

        public List<Department> GetDepartmentList()
        {
            Department model = new Department();

            List<Department> Departmentlist=model.DepartmentList.ToList();
            return Departmentlist;
        }
    }
}