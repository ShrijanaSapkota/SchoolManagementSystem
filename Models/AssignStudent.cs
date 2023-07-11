using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class AssignStudent
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DepartmentId { get; set; }
        public int SemesterId { get; set; }
    }

    public class AssignStudentVm
    {
        public int StudentId { get; set; }

        public string FullName { get; set; }

        public string DepartmenttName { get; set; }

        public string SemesterName { get; set; }
    }
}