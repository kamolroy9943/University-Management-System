using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using UniversityManagementApp.Models;
using UniversityManagementApp.BLL;


namespace UniversityManagementApp.Controllers
{
    public class TeacherAssignController : Controller
    {

        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();

        TeacherManager teacherManager = new TeacherManager();
        public ActionResult Index()
        {
            List<Department> departmentList = departmentManager.GetAllDepartment();
            ViewBag.departmentList = departmentList;
            return View();
        }

        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            var teacher = teacherManager.GetTeacher();
            var teacherList = teacher.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseDepartmentId(int departmentId)
        {
            var course = courseManager.GetAssignCourse();
            var courseList = course.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeacherCredit(int teacherId)
        {
            var teacherCreditList = teacherManager.GetTeacherCreditInfo(teacherId);
            return Json(teacherCreditList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseById(int CourseId)
        {
            var courses = courseManager.GetAssignCourse();
            var courseList = courses.Where(a => a.Id == CourseId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsCourseAssign(int TeacherId, int CourseId)
        {
            bool assigned = courseManager.IsCourseAssign(CourseId);
            if(assigned == true)
            {
                return Json(false);
            }
            else
            {
                int isSaved = teacherManager.saveAssign(TeacherId, CourseId);
                if (isSaved > 0)
                {
                    return Json(true);
                }
               
            }

            return Json(false);

        }
        


    }
}
