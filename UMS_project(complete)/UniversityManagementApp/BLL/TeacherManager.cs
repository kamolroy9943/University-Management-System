using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using UniversityManagementApp.DAL;

namespace UniversityManagementApp.BLL
{
    public class TeacherManager
    {
        TeacherGateWay teacherGateWay = new TeacherGateWay();
        public List<Designation> GetAllDesignation()
        {
            List<Designation> designationList = teacherGateWay.GetAllDesignation();
            return designationList;
        }

        public List<Teacher> GetTeacher()
        {
            return teacherGateWay.GetTeacher();
        }

        public List<TeacherShowAll> GetAllTeacher()
        {
            TeacherGateWay teacherGateWay = new TeacherGateWay();
            List<TeacherShowAll> teacherList = teacherGateWay.GetAllTeacher();
            return teacherList;
        }

        public bool IsTeacherEmailExits(string email)
        {
            TeacherGateWay teacherGateWay = new TeacherGateWay();
            bool isTeacherEmailExits = teacherGateWay.IsTeacherEmailExits(email);
            return isTeacherEmailExits;
        }

        public bool IsTeacherContactNoExits(string contactNo)
        {
            TeacherGateWay teacherGateWay = new TeacherGateWay();
            bool isTeacherContactNoExits = teacherGateWay.IsTeacherContactNoExits(contactNo);
            return isTeacherContactNoExits;
        }

        public int SaveTeacher(Teacher teacher)
        {
            TeacherGateWay teacherGateWay = new TeacherGateWay();
            int rowAffected = teacherGateWay.SaveTeacher(teacher);
            return rowAffected;
        }

        public List<TeacherShowAll> GetTeacherCreditInfo(int teacherId)
        {
            return teacherGateWay.GetTeacherCreditInfo(teacherId);
        }

        public int saveAssign(int teacherId, int courseId)
        {
            return teacherGateWay.saveAssign(teacherId, courseId);
        }
    }
}