using DBSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBSchoolManagementSystem.Controllers
{
    public class AssignmentController : Controller
    {
        SchoolManagement db = new SchoolManagement();
        // GET: Assignment
        public ActionResult Index()
        {
            Assignment model = new Assignment();
            model.AssignmentList = new List<Assignment>();
            model.AssignmentList = db.Assignment.ToList();

            return View(model);
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Assignment model, HttpPostedFileBase[] uploadedFiles)
        {
           
            // Save assignment details to the database
            // ...
           
            // Handle file upload
            if (uploadedFiles != null && uploadedFiles.Length > 0)
            {
                foreach (var file in uploadedFiles)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        // Generate a unique filename
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        // Save the file to a designated folder
                        var filePath = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                        file.SaveAs(filePath);

                        // Store the file details in the database
                        var uploadedFile = new UploadedFile
                        {
                            FileName = fileName,
                            FilePath = filePath
                        };
                        model.UploadedFiles.Add(uploadedFile);
                    }
                }
            }
            if (ModelState.IsValid)
            {

                db.Assignment.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

            // Save changes to the database
            // ...

            //return RedirectToAction("Index");
        }
    }
}