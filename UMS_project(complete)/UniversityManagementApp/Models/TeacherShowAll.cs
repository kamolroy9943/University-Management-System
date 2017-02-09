using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class TeacherShowAll
    {
       
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }
        public int CreditToBeTaken { get; set; }
        public int TotalCredit { get; set; }
    }
}