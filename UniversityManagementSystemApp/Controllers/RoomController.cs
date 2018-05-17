using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class RoomController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        CourseManager aCourseManager = new CourseManager();
        RoomAndDayManager aRoomAndDayManager = new RoomAndDayManager();
        AllocateClassRoomManager aAllocateClassRoomManager = new AllocateClassRoomManager();
        ViewRoutineManager aRoutineManager = new ViewRoutineManager();
        //
        // GET: /Room/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult AllocateClassRoom()
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.Departmentlist = aDepartments;
            List<Day> aDays = aRoomAndDayManager.GetAllDay();
            ViewBag.Daylist = aDays;
            List<Room> aRooms = aRoomAndDayManager.GetAllRoom();
            ViewBag.RoomList = aRooms;
            return View();
        }
        [HttpPost]
        public ActionResult AllocateClassRoom(string unassignSubmit, string submit,AllocateClassRoom allocateClassRoom)
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.Departmentlist = aDepartments;
            List<Day> aDays = aRoomAndDayManager.GetAllDay();
            ViewBag.Daylist = aDays;
            List<Room> aRooms = aRoomAndDayManager.GetAllRoom();
            ViewBag.RoomList = aRooms;
            if (submit!=null)
            {
                string message = aAllocateClassRoomManager.SaveAlocateClassRoom(allocateClassRoom);
                ViewBag.message = message;
            }
            if (unassignSubmit != null)
            {
                string unallocationMessage = aRoomAndDayManager.ClassroomUnassign();
                ViewBag.unallocationMessage = unallocationMessage;
            }
            return View();
        }
       
        public JsonResult GetCourseBydeptId(int departmentId)
        {
            var course = aCourseManager.GetAllCourse();
            var acourseList = course.Where(a => a.Department_Id == departmentId).ToList();
            return Json(acourseList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewRoutine()
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.DepatmentList = aDepartments;
            return View();
        }
        public JsonResult ViewFullRoutine(int Department_Id)
        {
            var aViewRoutine = aRoutineManager.GetAllViewCRoutines(Department_Id);
            var aViewCoursesList = aViewRoutine.ToList();
            return Json(aViewCoursesList, JsonRequestBehavior.AllowGet);
        }
    }
}