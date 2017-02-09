using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementApp.Models
{
    public class Result
    {
        [Required]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Please Select a Course")]
        public int CourseId { get; set; }
        [Required]
        public string Grade { get; set; }
        public string Code { get; set; }
        public string CourseCode{ get; set; }
    }
}