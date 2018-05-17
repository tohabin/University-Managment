using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        DepartmentManager aDepartmentManager = new DepartmentManager();
        StudentManager aStudentManager = new StudentManager();
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult RegisterStudent()
        {
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            ViewBag.Departmentlist = aDepartments;
            return View();
        }
        [HttpPost]
        public ActionResult RegisterStudent(Student aStudent)
        {
            //aStudent.RegistrationDate = Convert.ToDateTime(aStudent.Date);
            List<Department> aDepartments = aDepartmentManager.GetAllDepartment();
            string aDepartmentsbyCode = aDepartmentManager.GetAllDepartmentbyId(aStudent.DepartmentId);
            ViewBag.Departmentlist = aDepartments;

            string regno = aDepartmentsbyCode + "-";
            regno += aStudent.RegistrationDate.Year.ToString();
            regno += "-";
            int regNoId = aStudentManager.GetRowCount(regno);
            //string s = (regNoId + 1).ToString("000");
            if (regNoId == 0)
            {
                regno += "00" + 1;
            }
            else
            {
                if (regNoId >= 1 && regNoId <= 9)
                {
                    int temp = regNoId + 1;
                    regno += "00" + temp;
                }
                else if (regNoId >= 10 && regNoId <= 99)
                {
                    int temp = regNoId + 1;
                    regno += "0" + temp;

                }
                else
                {
                    regno += "" + regNoId + 1;

                }


            }
            aStudent.RegistrationNumber = regno;



            string saveStudent = aStudentManager.SaveStudent(aStudent);
            ViewBag.message = saveStudent;
            return View();
        }
        
	}
}