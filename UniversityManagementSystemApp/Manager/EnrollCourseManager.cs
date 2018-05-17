using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class EnrollCourseManager
    {
        EnrollCourseGateway enrollCourseGateway = new EnrollCourseGateway();

        public string SaveEnrolledCourse(EnrollCourse enrollCourse)
        {
            if (enrollCourseGateway.IsCourseEnrolled(enrollCourse.CourseId,enrollCourse.StudentId))
            {
                int rowAfeected = enrollCourseGateway.SaveEnrolledCourse(enrollCourse);
                if (rowAfeected > 0)
                {
                    return "Course Assigend sucessfull"; 
                }
                else
                {
                    return "Course Assigend not sucessfull";
                }
            }
            else
            {
                return "Course Already Assigned";
            }
        }
    }
}