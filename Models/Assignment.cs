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
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        [NotMapped]
        public ICollection<UploadedFile> UploadedFiles { get; set; }
        [NotMapped]
        public List<Assignment> AssignmentList { get;  set; }
    }
    public class UploadedFile
    {
    
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        // Additional properties if needed
    }

}