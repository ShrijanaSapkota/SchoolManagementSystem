using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class HomePageModel
    {
        [Key]
        public int Id { get; set; }
        public int InstructorCount { get; set; }
        public int StudentCount { get; set; }
        public int CourseCount { get; set; }
        public int DepartmentCount { get; set; }
    }
}