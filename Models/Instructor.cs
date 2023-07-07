using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class Instructor
    {
        
       
        [Key]
        public int Instructorid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Courses { get; set; }
        public int? TypeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? Courseid { get; set; }
        [NotMapped]
        public string RoleId { get; set; }
        [NotMapped]
        public int Id { get; set; }


        //public  EmployeeType EmployeeType { get; set; }
        [NotMapped]
        public List<Instructor> InstructorList { get;  set; }

       
    }
}