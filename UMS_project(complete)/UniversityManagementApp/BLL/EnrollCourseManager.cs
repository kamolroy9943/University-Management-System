using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.DAL;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.BLL
{
    public class EnrollCourseManager
    {
        EnrollCourseGateWay enrollCourseGateWay = new EnrollCourseGateWay();
        public List<EnrollCourseViewModel> GetAllStudent()
        {
            return enrollCourseGateWay.GetAllStudent();
        }

        public List<Course> GetStudentCourses(int departmentId)
        {
            return enrollCourseGateWay.GetStudentCourses(departmentId);
        }

        public bool saveEnroll(int studentId, int courseId, DateTime Date)
        {
            return enrollCourseGateWay.saveEnroll(studentId, courseId, Date);
        }

        public bool UnassignAllCourse()
        {
            return enrollCourseGateWay.UnassignAllCourse();
        }
    }
}