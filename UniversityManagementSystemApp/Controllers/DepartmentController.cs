using System.Collections.Generic;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        //
        // GET: /Department/
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(Department aDepartment)
        {
            string message = aDepartmentManager.Save(aDepartment);
            ViewBag.message = message;
            
            return View();
        }

        public ActionResult ViewDepartment()
        {
            List<Department> aDepartmensList = aDepartmentManager.GetAllDepartment();
            ViewBag.aDepartmensList = aDepartmensList;
            return View();
        }

	}
}