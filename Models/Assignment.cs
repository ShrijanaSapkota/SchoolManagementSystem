using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }
        public int Courseid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

    }

    public class StudentAssignment
    {
        public int StudentAssignmentId { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
        public DateTime SubmissionDate { get; set; }
    }

}