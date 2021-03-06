﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class CourseStaticsViewModel
    {
        [Required(ErrorMessage = "Please Select a Department")]
        public int DepartmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public string AssignedTo { get; set; }
    }
}