using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.BLL;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class EnrollCourseController : Controller
    {
        EnrollCourseManager entrollCourseManager = new EnrollCourseManager();
        // GET: EnrollCourse
        public ActionResult Index()
        {
            List<EnrollCourseViewModel> studentList = entrollCourseManager.GetAllStudent();
            ViewBag.studentList = studentList;
            return View();
        }

        public JsonResult GetStudentById(int StudentId)
        {
            List<EnrollCourseViewModel> studentList = entrollCourseManager.GetAllStudent();
            var aStudent = studentList.Where(a => a.StudentId == StudentId).ToList();
            return Json(aStudent, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStudentCourses(int DepartmentId)
        {
            List<Course> courseList = entrollCourseManager.GetStudentCourses(DepartmentId);
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult saveEnroll(int StudentId, int CourseId, DateTime Date)
        {
            bool isSaved = entrollCourseManager.saveEnroll(StudentId, CourseId, Date);
            if (isSaved)
            {
                return Json(true);

            }
            else
            {
                return Json(false);
            }

        }

        //public JsonResult saveEnroll(int StudentId, int CourseId, DateTime Date)
        //{
        //    bool isSaved = entrollCourseManager.saveEnroll(StudentId, CourseId, Date);
        //    if (isSaved)
        //    {
        //        return Json("Enroll successful");
                
        //    }
        //    else
        //    {
        //        return Json(false);
        //    }
            
        //}

        public ActionResult UnassignCourse()
        {
            return View();
        }


        public JsonResult UnassignAllCourse()
        {
            bool isUnassigned = entrollCourseManager.UnassignAllCourse();
            if (isUnassigned)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
            
        }
    }

}