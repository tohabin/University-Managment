using UniversityManagementSystemApp.DAL.Gateway;

using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class AssignCourseManager
    {
        AssignCourseGateway assignCourseGateway = new AssignCourseGateway();
        TeacherGateway aTeacherGateway = new TeacherGateway();

        public string SaveAssignedCourse(AssignCourse assignCourse)
        {
            if (assignCourseGateway.IsCourseAssigned(assignCourse.Course_Id))
            {
                int rowAfeected = assignCourseGateway.SaveAssignedCourse(assignCourse);
                if (rowAfeected>0)
                {
                    decimal tempCredit = assignCourse.Creditremain - assignCourse.Credit;
                    int rowAfeectedbyUpdate = aTeacherGateway.UpdateCredittoremain(tempCredit,assignCourse.Teacher_Id);
                    if (rowAfeectedbyUpdate > 0)
                    {
                        return "Course Assigend sucessfull"; 
                    }
                    else
                    {
                        return "Credit no updated";

                    }
                    //return "Course Assigend sucessfull"; 
                    

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

        public int UnssignedCourse()
        {
            int rowAfeected = assignCourseGateway.UnssignedCourse();
            return rowAfeected;
        }
    }
}