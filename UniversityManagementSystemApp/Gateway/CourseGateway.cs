using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class CourseGateway :Gateway
    {
        public bool IsExixstByCode(string code)
        {
            Query = "SELECT * FROM Course WHERE Code='" + code + "'";
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

        public int AddCourse(Course aCourse)
        {
            Query = "INSERT INTO Course(Code,Name,Credit,Description,Department_Id,Semester_Id)Values('"+aCourse.Code+"','"+aCourse.Name+"','"+aCourse.Credit+"','"+aCourse.Description+"','"+aCourse.Department_Id+"','"+aCourse.Semester_Id+"')";
            
            Command = new SqlCommand(Query, Connection);
            
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }

        public bool IsExixstByName(string name)
        {
            Query = "SELECT * FROM Course WHERE Name='" +name + "'";
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

        public List<Course> GetAllCourse()
        {
            Query = "SELECT * FROM Course";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            List<Course> aCourses = new List<Course>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course aCourse = new Course()
                {
                    Id = (int)Reader["Id"],
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString(),
                    Credit =  Convert.ToDecimal(Reader["Credit"]),
                    Department_Id = (int) Reader["Department_Id"]

                };
                aCourses.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return aCourses;
            

        }

        public List<Course> GetCourseByRegtId(int regId)
        {
            Query = "SELECT Course.Id,Course.Code FROM Student RIGHT JOIN Course ON Course.Department_Id=Student.DepartmentId LEFT JOIN Enrolled ON Course.Id=Enrolled.Course_ID WHERE Student.Id='" + regId + "'";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            List<Course> aCourses = new List<Course>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Course aCourse = new Course()
                {
                    Id = (int)Reader["Id"],
                    Code = Reader["Code"].ToString(),

                };
                aCourses.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return aCourses;

        }

        public int SaveGrade(EnrollCourse aCourse)
        {
            Query = "UPDATE Enrolled SET GradeId= '" + aCourse.GradeId + "' WHERE Course_ID='" + aCourse.CourseId + "' AND Student_ID='" + aCourse.StudentId + "' AND Status_Id='1'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int CourseUnassign()
        {
            Query = "UPDATE Course SET StatusId=0";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}