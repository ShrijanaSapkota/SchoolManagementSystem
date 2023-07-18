using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBSchoolManagementSystem.Models
{
    public class leaveNote
    {
        [Key]
        public int Id { get; set; }
       
        public int StudentId { get; set; }
        [NotMapped]
        public string FullName { get; set; }
     
        public virtual Student Student { get; set; }
        
        public int Instructorid { get; set; }
        [NotMapped]
        public string FirstName { get; set; }
        [NotMapped]
        public virtual Instructor Instructor { get; set; }

        [Required(ErrorMessage = "Please enter the leave note.")]
        public string Note { get; set; }
     
        public bool IsApproved { get; set; }
       
        public bool IsRejected { get; set; }

        public DateTime Date { get; set; }
        [NotMapped]
        public List<leaveNote> LeaveNoteList { get;  set; }
    }
    public class leaveNoteVm
    {
        public int Id { get; set; }
        [NotMapped]
        public int StudentId { get; set; }
        [NotMapped]

        public int Instructorid{ get; set; }

        public string FullName { get; set; }    

        public string FirstName { get; set; }
        public bool IsApproved { get; set; }

        public bool IsRejected { get; set; }

        public string Note { get; set; }  
        public DateTime Date { get; set; }
    }
}