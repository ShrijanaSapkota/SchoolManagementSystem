using DBSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBSchoolManagementSystem.Controllers
{
    public class HelpersController : Controller
    {
        // GET: Helpers
        public ActionResult Index()
        {
            return View();
        }

        public class SelectListVM
        {
            public int Id { get; set; }

            public string Idstr { get; set; }
            public string Title { get; set; }

            public int ProvinceId { get; set; }
            public string ProvinceTitleNep { get; set; }
        }

        public ActionResult GetCourseByDepartmentIdDD(int? id)
        {
            using (SchoolManagement db = new SchoolManagement())
            {

                List<SelectListItem> ddlList = new List<SelectListItem>();
                var collection = db.Database.SqlQuery<SelectListVM>(@"select CourseId as Id, CourseName as Title from Course where DepartmentId='" + id + "'").ToList();
                ddlList.Add(new SelectListItem { Text = "--Select--", Value = "0", Selected = true });
                foreach (var item in collection)
                {
                    ddlList.Add(new SelectListItem { Text = item.Title.ToString(), Value = item.Id.ToString() });
                }
                var ddlSelectOptionList = ddlList;


                return Json(ddlSelectOptionList, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetStudentSubjectByStudentIdDD(int? id)
        {
            using (SchoolManagement db = new SchoolManagement())
            {

                List<SelectListItem> ddlList = new List<SelectListItem>();
                var collection = db.Database.SqlQuery<SelectListVM>(@"select SubjectId as Id, SubjectName as Title from Subject where StudentId='" + id + "'").ToList();
                ddlList.Add(new SelectListItem { Text = "--Select--", Value = "0", Selected = true });
                foreach (var item in collection)
                {
                    ddlList.Add(new SelectListItem { Text = item.Title.ToString(), Value = item.Id.ToString() });
                }
                var ddlSelectOptionList = ddlList;


                return Json(ddlSelectOptionList, JsonRequestBehavior.AllowGet);
            }
        }



    }
}