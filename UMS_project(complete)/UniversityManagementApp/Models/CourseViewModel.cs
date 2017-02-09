using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class CourseViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Credit { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public string Semester { get; set; }
    }
}