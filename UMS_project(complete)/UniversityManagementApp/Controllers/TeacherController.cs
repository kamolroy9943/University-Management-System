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
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        DepartmentManager departmentManager = new DepartmentManager();
        TeacherManager teacherManager = new TeacherManager();
        public ActionResult Index()
        {
            List<Department> departmentList = departmentManager.GetAllDepartment();
            ViewBag.departmentList = departmentList;
            List<Designation> designationList = teacherManager.GetAllDesignation();
            ViewBag.designationList = designationList;
            List<TeacherShowAll> teacherList = teacherManager.GetAllTeacher();
            ViewBag.TeacherList = teacherList;
            ViewBag.Message = TempData["Message"];
            return View();
        }
        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            
            List<Department> departmentList = departmentManager.GetAllDepartment();
            ViewBag.departmentList = departmentList;
            List<Designation> designationList = teacherManager.GetAllDesignation();
            ViewBag.designationList = designationList;
            List<TeacherShowAll> teacherList = teacherManager.GetAllTeacher();
            ViewBag.TeacherList = teacherList;
            bool isTeacherEmailExist = teacherManager.IsTeacherEmailExits(teacher.Email);
            bool isTeacherContactNoExits = teacherManager.IsTeacherContactNoExits(teacher.ContactNo);
            
            if (isTeacherEmailExist)
            {
                TempData["Message"] = "Email already exist";
            }
            else if (isTeacherContactNoExits)
            {
                TempData["Message"] = "Contact No already exist";
            }
            else
            {
                int rowAffected = teacherManager.SaveTeacher(teacher);
                if (rowAffected > 0)
                {
                    TempData["Message"] = "Teacher Saved";
                }
                else
                {
                    TempData["Message"] = "Teacher Not Saved.Connection Broken";
                }
            }
            return Redirect("Index");
        }
	}
}