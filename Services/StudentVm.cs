using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Services
{
    public class StudentVm
    {
        [Key]
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public int DepartmentId { get; set; }

        public int CourseId { get; set; }

        public int TypeId { get; set; }
        [NotMapped]

        public List<StudentVm> StudentVmList { get; set; }
    }
}