using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.BLL;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class CourseController : Controller
    {
        CourseManager courseManager = new CourseManager();
        DepartmentManager departmentManager = new DepartmentManager();

        public ActionResult Index()
        {
            List<Department> departmentList = departmentManager.GetAllDepartment();
            ViewBag.departmentList = departmentList;

            List<Semester> semesterList = courseManager.GetAllSemester();
            ViewBag.semesterList = semesterList;

            List<CourseViewModel> courseViewList = courseManager.GetCourseView();
            ViewBag.courseViewList = courseViewList;

            ViewBag.Message = TempData["Message"];
            return View();
        }

        public ActionResult Save(Course course)
        {
            
            bool IsCodeExists = courseManager.IsUniqueValue("Course", "Code", course.Code);
            bool IsNameExists = courseManager.IsUniqueValue("Course", "Name", course.Name);

            if (IsCodeExists)
            {
                TempData["Message"] = "Course Code Exits.";
            }
            else if (IsNameExists)
            {
                TempData["Message"] = "Course Name Exits.";
            }
            else
            {
                int Saved = courseManager.SaveCourse(course);
                if (Saved > 0)
                {
                    TempData["Message"] = "Saved Successfully.";
                }

            }

            return Redirect("Index");
        }

        public ActionResult CourseStaticsView() {
            List<Department> departmentList = departmentManager.GetAllDepartment();
            ViewBag.departmentList = departmentList;
            return View();
        }

        public ActionResult loadCourseInfo(int departmentId)
        {
            List<CourseStaticsViewModel> courseStaticsViewList = courseManager.loadCourseInfo(departmentId);
            ViewBag.courseStaticsViewList = courseStaticsViewList;
            return PartialView("CourseStaticsParticalView");
        }
        

    }
}