using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBSchoolManagementSystem.Models
{
    public class StudentSubject
    {
        [Key]
        public int SSID { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
       
        public List<StudentSubject> StudentSubjectList { get; set; }

        
    }
}