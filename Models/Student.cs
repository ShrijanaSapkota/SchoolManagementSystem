using DBSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DBSchoolManagementSystem.Controllers
{
    public class Student
    {

        [Key]
        
        public int StudentId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }

        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [Display(Name= "Studentemail")]
        public string Email { get; set; }
        [StringLength(10, ErrorMessage = "Do not enter more than 10 characters")]
        public string Contactno { get; set; }
        public string Gender { get; set; }
       
        
        public DateTime EnrollmentDate { get; set; }
        [NotMapped]
        public string Programme { get; set; }

        [Display(Name = "Programme")]
        public int? TypeId { get; set; }

       public int? SubjectId   { get; set; }
        //public int? SSID { get; set; } = 0;

        public string Studentimg { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [NotMapped]
        public List<Student> StudentList { get; set; }
        [NotMapped]
        public List<StudentVm> StudentVmList { get; set; }

        [NotMapped]
        public List<StudentSubject> StudentSubjectList { get; set; }
       
    }
    public class StudentVm
    {
        public int StudentId { get; set; }
        public String FullName { get; set; }

        public String Address { get; set; }

        public String Email { get; set; }
    }
}