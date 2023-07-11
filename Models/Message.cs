using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class Message
    {
        public int StudentId { get; set; }
        public int InstructorId { get; set; }
        public int Courseid { get; set; }
        public string UserId { get; set; }
    }
}