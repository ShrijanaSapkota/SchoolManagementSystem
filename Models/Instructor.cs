
namespace DBSchoolManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public  class Instructor
    {
        public int Instructorid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Office { get; set; }
        public string Courses { get; set; }
        [NotMapped]
        public string Post { get; set; }
        [Display(Name ="Post")]
        public int? TypeId { get; set; }
        [Display(Name = "DepartmentName")]
        public int?  DepartmentId { get; set; }

        [Display(Name ="CourseName")]
        public int? CourseId { get; set; }


        [NotMapped]
        public List<Instructor> InstructorList { get;  set; }
    }
}