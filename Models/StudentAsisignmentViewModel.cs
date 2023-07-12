using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class StudentAsisignmentViewModel
    {
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        
        

    }
}