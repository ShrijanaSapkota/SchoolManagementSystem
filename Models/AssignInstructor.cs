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
      
		public int Instructorid { get; set; }
        
		public int Courseid { get; set; }
        

		public int DepartmentId { get; set; }
       
        


    }
    public class AssignInstructorVm
    {

        public int Courseid { get; set; }

        public int Instructorid { get; set; }
        public int DepartmentId { get; set; }


        public string CourseName { get; set; }
   

        public string InstructorName { get; set; }



        public string DepartmenttName { get; set; }

   


    }
}