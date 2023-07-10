using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int InstructorId { get; set; }

        public int CourseId { get; set; }

        public int SemesterId { get; set; }
        public int DepartmentId { get; set; }
        [NotMapped]
        public List<Subject> Subjects { get; set; }


    }
}