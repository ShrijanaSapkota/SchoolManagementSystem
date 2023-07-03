

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using DBSchoolManagementSystem.Services;

namespace DBSchoolManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Student name is required")]
        public string FullName { get; set; }
        public string Address { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Email { get; set; }
        [StringLength(11, ErrorMessage = "Do not enter more than 11 characters")]
        public string Contactno { get; set; }
        [Display(Name = "Enrollment Date")]
        public DateTime? EnrollmentDate { get; set; }
        [NotMapped]
        public string Course { get; set; }
        [Display(Name = "Course")]
        public int? TypeId { get; set; }

        public string Studentimg { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        //[NotMapped]
        //public int SSID { get; set; }
        [NotMapped]
        public int SubjectId { get; set; }
        [NotMapped]
        public List<Student> StudentList { get; set; }
        [NotMapped]
        public List<StudentVm> StudentVmList { get;  set; }
        [NotMapped]
        public List<StudentSubject> StudentSubjectList { get; set; }
        public List<Vm> VmList { get; internal set; }
    }
    public class StudentVM
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}