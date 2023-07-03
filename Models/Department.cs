using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmenttName { get; set; }
        [NotMapped]
        public List<Department> DepartmentList { get;  set; }
    }
}