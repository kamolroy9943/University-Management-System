using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using UniversityManagementApp.DAL;

namespace UniversityManagementApp.BLL
{   
    public class CourseManager
    {
        CourseGateWay courseGateWay = new CourseGateWay();
        public List<Semester> GetAllSemester()
        {
            return courseGateWay.GetAllSemester();
        }

        public List<Course> GetCourse()
        {
            return courseGateWay.GetCourse();
        }
        


        public bool IsUniqueValue(string table, string column, string value)
        {
            return courseGateWay.IsUniqueValue(table, column, value);
        }

        public int SaveCourse(Course course)
        {
            return courseGateWay.SaveCourse(course);
        }

        public List<CourseViewModel> GetCourseView()
        {
            return courseGateWay.GetCourseView();
        }

        public List<Course> GetAssignCourse()
        {
            return courseGateWay.GetCourse();
        }

        public bool IsCourseAssign(int CourseId)
        {
            return courseGateWay.IsCourseAssign(CourseId);
        }

        public List<CourseStaticsViewModel> loadCourseInfo(int departmentId)
        {
            return courseGateWay.loadCourseInfo(departmentId);
        }
    }
}