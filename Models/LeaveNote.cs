using System;
using System.ComponentModel.DataAnnotations;

namespace DBSchoolManagementSystem.Models
{
    public class LeaveNote
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int Instructorid { get; set; }
        public virtual Instructor Instructor { get; set; }

        [Required(ErrorMessage = "Please enter the leave note.")]
        public string Note { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }

        public DateTime Date { get; set; }
    }
}