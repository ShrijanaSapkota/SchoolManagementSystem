using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class SubmitAssignment
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
        public string UploadFile { get; set; }
    }
    public class SubmitAssignmentVm
    {
        public int AssignmentId { get; set; }
        [NotMapped]
        public int StudentId { get; set; } 
       
        public string FullName { get; set; }
       
        public string Title { get; set; }
        
        public string UploadFile { get; set; }
        [NotMapped]
            public HttpPostedFileBase FileUrl { get; set; }
           
            
        

    }
}