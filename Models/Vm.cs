using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBSchoolManagementSystem.Services
{

    public class Vm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int DepartmentId { get; set; }

        public int CourseId { get; set; }

        public int TypeId { get; set; }

        public List<Vm> VmList { get; set; }

    }
}