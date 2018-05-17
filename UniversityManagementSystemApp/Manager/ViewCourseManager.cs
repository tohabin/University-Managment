using System.Collections.Generic;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class ViewCourseManager
    {
        ViewCourseGateway aViewCourseGateway =new ViewCourseGateway();

        public List<ViewCourse> GetAllViewCourse(int deptID)
        {

            List<ViewCourse> aViewCourses = aViewCourseGateway.GetAllViewCourse(deptID);
            return aViewCourses;
        }
    }
}