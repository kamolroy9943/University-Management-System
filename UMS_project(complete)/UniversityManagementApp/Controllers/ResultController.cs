using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.BLL;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class ResultController : Controller
    {
        EnrollCourseManager entrollCourseManager = new EnrollCourseManager();
        ResultManager resultManager = new ResultManager();
        // GET: Result
        public ActionResult Index()
        {
            List<EnrollCourseViewModel> studentList = entrollCourseManager.GetAllStudent();
            ViewBag.Grades = GetGrades();
            ViewBag.studentList = studentList;
            return View();
        }
        [HttpPost]

        public JsonResult saveResult(Result result)
        {
            string msg;
            if (ModelState.IsValid)
            {
                bool isSaved = resultManager.saveResult(result);
                if (isSaved)
                {
                    return Json(new { msg = "Saved" }, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(new { msg = "Exist" }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new { msg = "Required" }, JsonRequestBehavior.AllowGet);

        }
        
        public JsonResult GetEnrollCourses(int StudentId)
        {
            List<Course> courseList = resultManager.GetEnrollCourses(StudentId);
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewResult()
        {
            List<EnrollCourseViewModel> studentList = entrollCourseManager.GetAllStudent();
            ViewBag.studentList = studentList;
            return View();
        }

        public ActionResult loadResultInfo(int StudentId)
        {
            List<Result> resultViewList = resultManager.loadResultInfo(StudentId);
            ViewBag.resultViewList = resultViewList;
            return PartialView("resultParticalView");
        }
        

        private List<Grade> GetGrades()
        {
            List<Grade> grades = new List<Grade>
            {
                new Grade {GradeName = "A+"},
                new Grade {GradeName = "A"},
                new Grade {GradeName = "A-"},
                new Grade {GradeName = "B+"},
                new Grade {GradeName = "B"},
                new Grade {GradeName = "B-"},
                new Grade {GradeName = "C+"},
                new Grade {GradeName = "C"},
                new Grade {GradeName = "C-"},
                new Grade {GradeName = "D+"},
                new Grade {GradeName = "D"},
                new Grade {GradeName = "D-"},
                new Grade {GradeName = "F"},


            };
            return grades;
        }
    }
}