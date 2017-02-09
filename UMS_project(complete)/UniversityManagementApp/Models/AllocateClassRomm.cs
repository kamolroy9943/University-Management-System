using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class AllocateClassRomm
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public int DepartmenetId { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        public int FromHour  { get; set; }
        [Required]
        public int FromMin { get; set; }
        [Required]
        public string FromDay { get; set; }
        [Required]
        public int ToHour { get; set; }
        [Required]
        public int ToMin { get; set; }
        [Required]
        public string ToDay { get; set; }
        
        public int Status { get; set; }
    }
}