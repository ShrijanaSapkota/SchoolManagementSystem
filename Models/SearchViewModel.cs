using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBSchoolManagementSystem.Models
{
    public class SearchViewModel
    {
        public string searchQuery { get; set; }
        public List<SelectListItem> InstructorList { get; set; }
        public List<SelectListItem> StudentList { get; set; }
    }
}