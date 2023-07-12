using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class Message
    {
        [Key]
        public int StudentId { get; set; }
        public int InstructorId { get; set; }
        public int Courseid { get; set; }
        public string UserId { get; set; }
   

    }
    public class MessageVm
    {
        public int AssignmentId { get; set; }

        public string FirstName { get; set; }

        public string CourseName { get; set; }

        public string SemesterName { get; set; }
    }
}