using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class StudentSubject
    {
        [Key]
        public int SSID { get; set; }
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        [Display(Name ="Subject")]
        public int SubjectId { get; set; }
        [NotMapped]
        public List<StudentSubject> StudentSubjectList { get;  set; }
    }

}