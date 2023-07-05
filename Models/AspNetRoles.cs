using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class AspNetRoles
    {
        public string Id{ get; set; }
        public string Name { get; set; }
        public List<AspNetRoles> AspNetRolesList { get;  set; }
    }
}