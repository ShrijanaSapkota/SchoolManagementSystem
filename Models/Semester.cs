using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }

        [NotMapped]
        public List<Semester> SemesterList { get;  set; }
    }
}