using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class CourseController : Controller
    {
        CourseManager aCourseManager = new CourseManager();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        SemesterManager aSemesterManager = new SemesterManager();
        TeacherManager aTeacherManager = new TeacherManager();
        AssignCourseManager assignCourseManager = new AssignCourseManager();
        ViewCourseManager aViewCourseManager = new ViewCourseManager();
        StudentManager aStudentManager =new StudentManager();
        EnrollCourseManager aEnrollCourseManager =new EnrollCourseManager();
        //
        // GET: /Course/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult AddCourse()
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.DepatmentList = aDepartments;
            List<Semester> aSemesters = aSemesterManager.GetAllSemester();
            ViewBag.SemesterList = aSemesters;
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(Course aCourse)
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.DepatmentList = aDepartments;
            List<Semester> aSemesters = aSemesterManager.GetAllSemester();
            ViewBag.SemesterList = aSemesters;

            string message = aCourseManager.AddCoures(aCourse);
            ViewBag.message = message;
            return View();
        }

        [HttpGet]
        public ActionResult AssignCourse()
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.DepatmentList = aDepartments;
            return View();

        }

        [HttpPost]
        public ActionResult AssignCourse(string unassignSubmit, string assignSubmit, AssignCourse assignCourse)
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.DepatmentList = aDepartments;
            if (assignSubmit!=null)
            {
                string message = assignCourseManager.SaveAssignedCourse(assignCourse);
                ViewBag.message = message;
            }
            if (unassignSubmit != null)
            {
                string message = aCourseManager.CourseUnassign();
                ViewBag.unassignmessage = message;
            }
            return View();
        }

        public ActionResult ViewCourse()
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.DepatmentList = aDepartments;
            return View();
        }

        [HttpGet]
        public ActionResult EnrollCourse()
        {
            List<Student> aStudents = aStudentManager.GetAllStudents();
            ViewBag.StudentList = aStudents;
            return View();
        }

        [HttpPost]
        public ActionResult EnrollCourse(EnrollCourse enrollCourse)
        {
            List<Student> aStudents = aStudentManager.GetAllStudents();
            ViewBag.StudentList = aStudents;
            string message = aEnrollCourseManager.SaveEnrolledCourse(enrollCourse);
            ViewBag.message = message;

            return View();
        }

        public JsonResult GetTeacherByDeptId(int Department_Id)
        {
            var aTeacher = aTeacherManager.GetAllTeacher();
            var teachers = aTeacher.Where(a => a.Department_Id == Department_Id).ToList();
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTeacherById(int Teacher_Id)
        {
            var aTeacher = aTeacherManager.GetAllTeacher();
            var ateacherslist = aTeacher.Where(a => a.Id == Teacher_Id).ToList();
            return Json(ateacherslist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseById(int Course_Id)
        {
            var course = aCourseManager.GetAllCourse();
            var courseList = course.Where(a => a.Id == Course_Id).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseBydeptId(int Department_Id)
        {
            var course = aCourseManager.GetAllCourse();
            var acourseList = course.Where(a => a.Department_Id == Department_Id).ToList();
            return Json(acourseList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ViewAssigendCourse(int Department_Id)
        {
            var aViewCourses = aViewCourseManager.GetAllViewCourse(Department_Id);
            var aViewCoursesList = aViewCourses.ToList();
            return Json(aViewCoursesList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStudentByRegtId(int StudentId)
        {
            var aViewCourses = aStudentManager.GetAllStudents();
            var aViewCoursesList = aViewCourses.Where(a => a.Id == StudentId).ToList();
            return Json(aViewCoursesList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCoursesByRegtId(int StudentId)
        {
            var aViewCourses = aCourseManager.GetAllStuGetCourseByRegtId(StudentId);
            var aViewCoursesList = aViewCourses.ToList();
            return Json(aViewCoursesList, JsonRequestBehavior.AllowGet);
        }
        
	}
}