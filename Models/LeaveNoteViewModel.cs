using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class LeaveNoteViewModel
    {
        [Required(ErrorMessage = "Please enter the leave note.")]
        public string Note { get; set; }
       

        [Required(ErrorMessage = "Please select the instructor.")]
        public int Instructorid { get; set; }
    }
}