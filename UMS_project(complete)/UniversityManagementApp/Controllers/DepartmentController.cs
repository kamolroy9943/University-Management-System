using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Models;
using UniversityManagementApp.BLL;
using UniversityManagementApp.Controllers;

namespace UniversityManagementApp.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        
        public ActionResult Index()
        {
            List<Department> departmentList = departmentManager.GetAllDepartment();
            ViewBag.departmentList = departmentList;
            ViewBag.Message = TempData["Message"];
            return View();
        }
        [HttpPost]
        public ActionResult Save(Department department)
        {
            bool IsCodeExists = departmentManager.IsCodeExits(department.Code);
            bool IsNameExists = departmentManager.IsNameExists(department.Name);
            List<Department> departmentList = departmentManager.GetAllDepartment();
            ViewBag.departmentList = departmentList;

            if (department.Code.Length <= 1 || department.Code.Length > 8)
            {
                TempData["Message"] = "Department Code must be 2 to 7 character";
            }
            else
            {
                if (IsCodeExists)
                {
                    TempData["Message"] = "Department Code Exits.";
                }
                else if (IsNameExists)
                {
                    TempData["Message"] = "Department Name Exits.";
                }
                else
                {

                    int Saved = departmentManager.SaveDepartment(department);
                    if (Saved > 0)
                    {
                        TempData["Message"] = "Saved Successfully.";
                    }

                }
            }
            return Redirect("Index");
        }
    }
}