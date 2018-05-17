using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class ViewCourseGateway:Gateway
    {
        public List<ViewCourse> GetAllViewCourse(int deptId)
        {

            Query = "SELECT Course.Code, Course.Name,Semester.Name as SemName,Teacher.Name as TeacherName FROM AssignedCourse Right JOIN Course ON Course.id=AssignedCourse.Course_Id LEFT JOIN Teacher ON Teacher.Id=AssignedCourse.Teacher_Id Inner JOIN Semester ON Course.Semester_Id=Semester.Id where Course.Department_ID='"+deptId+"' order by Code";
            Command = new SqlCommand(Query,Connection);
            List<ViewCourse> aViewCourses = new List<ViewCourse>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewCourse aViewCourse =new ViewCourse
                {

                    CourseCode = Reader["Code"].ToString(),
                    CourseName = Reader["Name"].ToString(),
                    CourseSemester = Reader["SemName"].ToString(),
                    TeacherName = Reader["TeacherName"].ToString()
                };
                aViewCourses.Add(aViewCourse);
            }
            Reader.Close();
            Connection.Close();
            return aViewCourses;


        }
    }
}