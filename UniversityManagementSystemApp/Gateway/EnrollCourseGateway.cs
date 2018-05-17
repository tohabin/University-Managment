using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class EnrollCourseGateway : Gateway
    {
        public bool IsCourseEnrolled(int courseId, int studentID)
        {
            int status = 1;
            Query = "SELECT * FROM Enrolled WHERE Status_Id ='" + status + "' AND Course_Id='" + courseId + "'AND Student_ID='" + studentID + "'  ";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            Reader = Command.ExecuteReader();
            bool isexixt;
            if (Reader.HasRows)
            {
                isexixt = false;
            }
            else
            {
                isexixt = true;
            }
            Reader.Close();
            Connection.Close();
            return isexixt;
        }

        public int SaveEnrolledCourse(EnrollCourse enrollCourse)
        {
            Query = "INSERT INTO Enrolled(Course_Id,Student_Id,GradeId,Status_Id) Values('" + enrollCourse.CourseId + "','" + enrollCourse.StudentId + "','" + enrollCourse.GradeId + "','1')";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}