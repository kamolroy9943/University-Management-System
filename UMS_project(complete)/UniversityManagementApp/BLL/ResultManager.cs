using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;
using UniversityManagementApp.DAL;

namespace UniversityManagementApp.BLL
{
    public class ResultManager
    {
        ResultGateWay resultGateWay = new ResultGateWay();
        public List<Course> GetEnrollCourses(int studentId)
        {
            return resultGateWay.GetEnrollCourses(studentId);
        }

        public bool saveResult(Result result)
        {
            return resultGateWay.saveResult(result);
        }

        public List<Result> loadResultInfo(int studentId)
        {
            return resultGateWay.loadResultInfo(studentId);
        }
    }
}