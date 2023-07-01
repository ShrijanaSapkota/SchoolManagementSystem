

namespace DBSchoolManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Course
    {
        [Key]
        public int Courseid { get; set; }
        public string CourseName { get; set; }
        public int DepartmentId { get; set; }

        [NotMapped]
        public List<Course> CourseList { get; set; }
    }
}
