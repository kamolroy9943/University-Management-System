using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class EnrollCourseViewModel
    {
        [Required(ErrorMessage = "Please Select a Registration No.")]
        public int StudentId { get; set; }
        public string RegistrationNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Please Select a Course.")]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Please Select a Date.")]
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public int Id { get; set; }
    }
}