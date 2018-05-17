using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class ResultController : Controller
    {
        
        StudentManager aStudentManager = new StudentManager();
        CourseManager aCourseManager = new CourseManager();
        GradeManager aGradeManager = new GradeManager();
        ViewResultManager aViewResult = new ViewResultManager();
        //
        // GET: /Result/
        [HttpGet]
        public ActionResult SaveResult()
        {
            List<Student> aStudents = aStudentManager.GetAllStudents();
            ViewBag.StudentList = aStudents;
            List<Grade> aGrades = aGradeManager.GetAllGrades();
            ViewBag.GradeList = aGrades;
            return View();
        }

        [HttpPost]
        public ActionResult SaveResult(EnrollCourse aCourse)
        {
            List<Student> aStudents = aStudentManager.GetAllStudents();
            ViewBag.StudentList = aStudents;
            List<Grade> aGrades = aGradeManager.GetAllGrades();
            ViewBag.GradeList = aGrades;
            string message = aCourseManager.SaveGrade(aCourse);
            ViewBag.message = message;
            return View();
        }
        public ActionResult ViewResult()
        {
            List<Student> aStudents = aStudentManager.GetAllStudents();
            ViewBag.StudentList = aStudents;
            //string message = aEnrollCourseManager.SaveEnrolledCourse(enrollCourse);
            return View();
        }

        public JsonResult GetCoursesByRegtId(int StudentId)
        {
            var aViewCourses = aCourseManager.GetAllStuGetCourseByRegtId(StudentId);
            var aViewCoursesList = aViewCourses.ToList();
            return Json(aViewCoursesList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ViewFullResult(int StudentId)
        {
            var aViewResults = aViewResult.GetAllViewResults(StudentId);
            var aViewResultList = aViewResults.ToList();
            return Json(aViewResultList, JsonRequestBehavior.AllowGet);
        }
       
       
    }
}