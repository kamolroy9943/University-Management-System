using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Models;
using UniversityManagementApp.BLL;

namespace UniversityManagementApp.Controllers
{
    public class StudentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        StudentManager studentManager = new StudentManager();
        public ActionResult Index()
        {
            List<Department> departmentList = departmentManager.GetAllDepartment();
            ViewBag.departmentList = departmentList;
            ViewBag.Message = TempData["Message"];
            return View();
        }

        public ActionResult Save(Student student)
        {
            if (ModelState.IsValid) {

                student.RegistrationNo = GetStudentRegNo(student);

                int Saved = studentManager.SaveStudent(student);
                if (Saved > 0)
                {
                    TempData["Message"] = "Saved Successfully.";
                }
            }

            return Redirect("Index");
        }

        public string GetStudentRegNo(Student aStudent)
        {
            List<Student> studentList = studentManager.GetAllStudent();
            var cnt =
                studentList.Count(m => (m.DepartmentId == aStudent.DepartmentId) && (m.Date.Year == aStudent.Date.Year)) +
                1;

            List<Department> departmentList = departmentManager.GetAllDepartment();
            var aDepartment = departmentList.FirstOrDefault(m => m.Id == aStudent.DepartmentId);

            string leadingZero = "";
            int length = 3 - cnt.ToString().Length;
            for (int i = 0; i < length; i++)
            {
                leadingZero += "0";
            }

            string studentRegNo = aDepartment.Code + "-" + aStudent.Date.Year + "-" + leadingZero + cnt;
            return studentRegNo;
        }

        [HttpGet]
        public JsonResult IsEmailExist(Student student)
        {
            List<Student> studentList = studentManager.GetAllStudent();
            bool isExist = studentList.Where(u => u.Email.ToLowerInvariant().Equals(student.Email.ToLower())).FirstOrDefault() != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
            
        }
    }
}