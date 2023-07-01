

using DBSchoolManagementSystem.Models;
using DBSchoolManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace DBSchoolManagementSystem.Controllers
{
    //[Authorize]
    public class StudentController : Controller
    {
        SchoolManagement db = new SchoolManagement();
        public ActionResult Index()
        {
            Student model = new Student();
            model.StudentList = new List<Student>();
            model.StudentList = db.Student.ToList();
            return View(model);
        }
        
        public ActionResult ListStudent()
        {
            StudentServices _SS = new StudentServices();
            Student model = new Student();
            model.StudentVmList = new List<StudentVm>();
            model.StudentVmList =_SS.GetStudentList();

            return View(model);
        }
      
        public ActionResult Create()
        {
            
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student model,HttpPostedFileBase ImageFile)
        {
            
                if (model.ImageFile != null && model.ImageFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    model.Studentimg = "../Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
                    model.ImageFile.SaveAs(fileName);
                }




                    using (SchoolManagement db = new SchoolManagement())
                    {
                        if (db.Student.Any(x => x.FullName == model.FullName))
                        {
                            ModelState.AddModelError("FullName", "Name Already Exist");
                        }
                        if(ModelState.IsValid)
                        {
                            db.Student.Add(model);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                    return View(model);
                
            

            
        }
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student model = new Student();
            model = db.Student.Find(id);
            if (model == null)
            {
                model = new Student();
            }
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Student model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    model.Studentimg = "../Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image"), fileName);
                    //model.ImageFile.SaveAs(fileName);
                    //return RedirectToAction("Index");
                    if(model.ImageFile.ContentLength<1000000)
                    {
                        db.Entry(model).State = EntityState.Modified;
                        if (db.SaveChanges() > 0)
                        {
                            model.ImageFile.SaveAs(fileName);
                        }
                        
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "File must be less than or equal to 1 MB");
                    }

                }
                
            }
            else
            {
                //model.Studentimg = Session["imgPath"].ToString();
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }


                
            
               return View(model);
        }

           
        

 


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student model = db.Student.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student model = db.Student.Find(id);
            db.Student.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student model = db.Student.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
      

        public ActionResult SaveStd()
        {
            Student model = new Student();
            model.EnrollmentDate = DateTime.Now;
            return View(model);
        }
        [HttpPost]
        public ActionResult SaveStd(Student model)
        {
            StudentServices _SS = new StudentServices();
            String message = _SS.InsertStudent(model);
            if (message == "Saved Successfully")
            {
                return RedirectToAction("Index");
            }
            ViewBag.Errormessage = message;
            return View(model);
        }

        public ActionResult Update(int id)
        {
            Student model = new Student();
            model = db.Student.Find(id);
            if (model == null)
            {
                model = new Student();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Student model)
        {
            StudentServices _SS = new StudentServices();
            String message = _SS.UpdateStudent(model);
            if (message == "Update Successfully")
            {
                return RedirectToAction("Index");
            }
            ViewBag.Errormessage = message;
            return View(model);
        }
        public ActionResult DeleteStd(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student model = db.Student.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("DeleteStd")]
        public ActionResult DeleteStd(int id)
        {
            Student model = new Student();
            model = db.Student.Find(id);
            StudentServices _SS = new StudentServices();
            String message = _SS.DeleteStudent(id);
            if (message == "Deleted Successfully")
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

     

    }
}