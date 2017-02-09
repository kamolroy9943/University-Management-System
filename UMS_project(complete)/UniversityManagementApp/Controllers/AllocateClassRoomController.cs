using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Models;
using UniversityManagementApp.BLL;
using UniversityManagementApp.DAL;

namespace UniversityManagementApp.Controllers
{
    public class AllocateClassRoomController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        AllocateRoomManager allocateRoomManager = new AllocateRoomManager();
        CourseManager courseManager = new CourseManager();
        // GET: AllocateClassRoom
        public ActionResult Index()
        {
            List<Department> departmentList = departmentManager.GetAllDepartment();
            List<Room> roomList = allocateRoomManager.GetAllRoom();
            List<Days> dayList = GetAllDay();
            ViewBag.departmentList = departmentList;
            ViewBag.roomList = roomList;
            ViewBag.dayList = dayList;
            ViewBag.Message = TempData["Message"];
            return View();
        }

        public JsonResult GetCoursesByDepartment(int departmentId)
        {
            var course = courseManager.GetCourse();
            var courseList = course.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Save(AllocateClassRomm allocateClassRomm)
        {
            if (ModelState.IsValid)
            {
                int isSaved = allocateRoomManager.Save(allocateClassRomm);
                if (isSaved > 0)
                {
                    TempData["Message"] = "Saved Successfully.";
                }
                else
                {
                    TempData["Message"] = "Failed.";
                }
                return Redirect("Index");
            } else
            {
                return Redirect("Index");
            }
            
        }

        public ActionResult UnallocateRoom()
        {
            return View();
        }

        public JsonResult UnassignAllCourse()
        {
            bool isUnassigned = allocateRoomManager.UnallocateAllRoom();
            if (isUnassigned)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }
        



        private List<Days> GetAllDay()
        {
            List<Days> days = new List<Days>
             {
                new Days { Day = "Saturday"},
                new Days { Day = "Sunday"},
                new Days { Day = "Monday"},
                new Days { Day = "Tuesday"},
                new Days { Day = "Wednesday"},
                new Days { Day = "Thursday"},
                new Days { Day = "Friday"}
            };
            return days;
          
        }
    }
}