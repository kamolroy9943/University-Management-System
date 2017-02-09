using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Remote("IsEmailExist", "Student", ErrorMessage = "Email already exist")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please provide your email")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please provide a valid email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Contact Number")]
        public string ContactNo { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Select a Department")]
        public int DepartmentId { get; set; }
        public string RegistrationNo { get; set; }
    }
}