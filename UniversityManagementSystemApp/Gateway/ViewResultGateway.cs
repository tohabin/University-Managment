using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class ViewResultGateway:Gateway
    {
        public List<ViewResult> GetAllViewResults(int stdId)
        {

            Query = "SELECT Course.Code, Course.Name,Grade.GradeLetter FROM Enrolled Left JOIN Course ON Course.id=Enrolled.Course_Id  LEFT JOIN Grade ON Enrolled.GradeId=Grade.Id WHERE Enrolled.Student_ID='" + stdId + "' AND Enrolled.Status_Id =1";
            Command = new SqlCommand(Query, Connection);
            List<ViewResult> getAllViewResults = new List<ViewResult>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewResult viewRoutine = new ViewResult
                {

                    CourseCode = Reader["Code"].ToString(),
                    CourseName = Reader["Name"].ToString(),
                    GradeLetter = Reader["GradeLetter"].ToString(),
                    
                };
                getAllViewResults.Add(viewRoutine);
            }
            Reader.Close();
            Connection.Close();
            return getAllViewResults;


        }
    }
}