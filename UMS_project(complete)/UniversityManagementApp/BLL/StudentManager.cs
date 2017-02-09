using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using UniversityManagementApp.DAL;

namespace UniversityManagementApp.BLL
{
    public class StudentManager
    {
        StudentGateWay studentGateWay = new StudentGateWay();
        public List<Student> GetAllStudent()
        {
            return studentGateWay.GetAllStudent();
        }

        public int SaveStudent(Student student)
        {
            return studentGateWay.SaveStudent(student);
        }
    }
}