using DBSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBSchoolManagementSystem.Controllers
{
    
    public class StudentSubjectController : Controller
    {
        SchoolManagement db = new SchoolManagement();
        // GET: SubjectStudent
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            StudentSubject SS = new StudentSubject();


            SS = new StudentSubject();
            SS.StudentSubjectList = new List<StudentSubject>();

            return View(SS);
        }



        [HttpPost]
        public ActionResult Create(StudentSubject SS)
        {

            if (ModelState.IsValid)
            {
                //SS.CreatedDate = DateTime.Now;
                //SS.CreatedBy = SchoolManagement.Web.Helpers.CommonFunction.GetCurrentUserString();
                foreach (var item in SS.StudentSubjectList)
                {


                    var detail = new StudentSubject()
                    {

                        StudentId = SS.StudentId,
                        SSID = SS.SSID,
                        SubjectId = item.SubjectId,
                        
                    };

                    //SS = db.StudentSubjectList.Add(detail);

                }

                db.SaveChanges();
                //TempData["Success"] = Helpers.HelperFunction.SaveSuccessMessage;



                return RedirectToAction("Index");


            }

            return View(SS);
        }




        [HttpPost]
        public ActionResult AddMore()
        {
            StudentSubject SS = new StudentSubject();

            SS.StudentSubjectList = new List<StudentSubject>();
            return PartialView("_Sstudent.cshtml");
        }


    }
}