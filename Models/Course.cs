

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class Course
    {
        [Key]
        public int Courseid { get; set; }
        public string CourseName { get; set; }
        public int DepartmentId { get; set; }

        public int SemesterId { get; set; }
        public int Instructorid { get; set; }
        [NotMapped]
        public List<Course> CourseList { get; internal set; }
    }
}
