using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
	public class AssignInstructor
	{
        [Key]
		public int Id { get; set; }
      
		public int InstructorId { get; set; }
        
		public int Courseid { get; set; }
        

		public int DepartmentId { get; set; }
        [NotMapped]
        public List<AssignInstructor> AssignInstructorList { get;  set; }
    }
}