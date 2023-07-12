using DBSchoolManagementSystem.Models;
using DBSchoolManagementSystem.Services;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static DBSchoolManagementSystem.Models.Instructor;


namespace DBSchoolManagementSystem.Controllers
{

    public class InstructorController : Controller
    {
            private ApplicationSignInManager _signInManager;
            private ApplicationUserManager _userManager;
            SchoolManagement db = new SchoolManagement();
           StudentServices _SS = new StudentServices();



        public InstructorController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
            {
                UserManager = userManager;
                SignInManager = signInManager;
            }

        public InstructorController()
        {

        }

        #region application
            public ApplicationSignInManager SignInManager
            {
                get
                {
                    return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
                }
                private set
                {
                    _signInManager = value;
                }
            }

            public ApplicationUserManager UserManager
            {
                get
                {
                    return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                }
                private set
                {
                    _userManager = value;
                }
            }
        #endregion

        #region crud
        public ActionResult Index()
        { 
            var model = db.Instructor.ToList();

            return View(model);
        } 
        public ActionResult Create()

        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Instructor model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await UserManager.CreateAsync(user, "Instructor@12345");
            if (result.Succeeded)
            {
                var myuser = await UserManager.FindByEmailAsync(model.Email);
                await UserManager.AddToRoleAsync(myuser.Id, "Instructor");
                model.UserId = myuser.Id;

                if (ModelState.IsValid)
                {
                    db.Instructor.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            return View();
        }

        public ActionResult Edit(int id)
        { 
           var model = db.Instructor.Find(id);
            if (model == null)
            {
                model = new Instructor();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Instructor model)
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
          var model = db.Instructor.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = db.Instructor.Find(id);
            db.Instructor.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Instructor.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        #endregion

        #region leavenotes
        public ActionResult ViewLeaveNotes()
        {
            
            var leaveNotes = _SS.GetLeaveNoteList();
          
             

            return View(leaveNotes);
        }

        [HttpGet]
        public ActionResult IsApproved(int id)
        {
            var leaveNotes = db.LeaveNotes.Find(id);
            leaveNotes.IsApproved = true;
            db.Entry(leaveNotes).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(nameof(ViewLeaveNotes));
        }
        public ActionResult IsRejected(int id)
        {
            var leaveNotes =db.LeaveNotes.Find(id);
            leaveNotes.IsRejected = true;
            db.Entry(leaveNotes).State=EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction(nameof(ViewLeaveNotes));
        }
        #endregion

        [HttpGet]
        public ActionResult CreateAssignment()
        {
            ViewBag.Course = db.Course.ToList();
            return View();
        }


        [HttpPost]
        public async Task<ActionResult>  CreateAssignment(Assignment assignment)
        {
            // Save the assignment to the database
            db.Assignment.Add(assignment);
            db.SaveChanges();
           

            return RedirectToAction("Index", "Home");

            var StudentList = _SS.GetAssignMessageList().Where(x=>x.Courseid==assignment.Courseid);

            // Assign the assignment to the selected students
            foreach (var item in StudentList)
            {
                var studentAssignment = new StudentAssignment
                {
                    StudentId = item.StudentId,
                    AssignmentId = assignment.AssignmentId,
                    SubmissionDate = DateTime.Now // Set the submission date to the current date
                };

                db.StudentAssignments.Add(studentAssignment);
            }

            db.SaveChanges();

            return RedirectToAction("MessageIndex", "Home");
        }
       

}

}
