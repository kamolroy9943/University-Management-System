using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.DAL;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.BLL
{
    public class DepartmentManager
    {
        DepartmenGateWay departmentGateWay = new DepartmenGateWay();
        public bool IsCodeExits(string code)
        {
            return departmentGateWay.IsCodeExits(code);
        }

        public bool IsNameExists(string name)
        {
            return departmentGateWay.IsNameExists(name);
        }

        public int SaveDepartment(Department department)
        {
            return departmentGateWay.SaveDepartment(department);
        }

        public List<Department> GetAllDepartment()
        {
            return departmentGateWay.GetAllDepartment();
        }
    }
}