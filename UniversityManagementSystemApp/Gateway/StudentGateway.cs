using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class StudentGateway :Gateway
    {
        public bool IsEmailExixt(string email)
        {
            

            Query = "SELECT * FROM Student WHERE Email='" + email + "'";
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

        public int SaveStudent(Student aStudent)
        {
            Query = "INSERT INTO Student(Name,Email,Contactno,Date,Address,DepartmentId,Registrationno) VALUES('" + aStudent.Name + "','" + aStudent.Email + "','" + aStudent.Contactno + "','" + aStudent.RegistrationDate + "','" + aStudent.Address + "','" + aStudent.DepartmentId + "','" + aStudent.RegistrationNumber + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int GetRowCount(string regno)
        {
            Query = "Select count(*) from Student where Registrationno  LIKE '%"+regno+"%'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = (int) Command.ExecuteScalar();
            Connection.Close();
            return rowAffected;
        }
        public List<Student> GetAllStudents()
        {
            Query = "SELECT  s.id, s.Name, s.Email, s.Contactno, s.Date, s.Address, s.DepartmentId, s.Registrationno,d.Code as DeptCode,d.Name as DeptName FROM Student as s JOIN Department as d ON s.DepartmentId=d.Id";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            List<Student> aStudents = new List<Student>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Student aStudent = new Student()
                {
                    Id = (int)Reader["Id"],
                    Email = Reader["Email"].ToString(),
                    Name = Reader["Name"].ToString(),
                    Contactno = Reader["Contactno"].ToString(),
                    RegistrationDate = (DateTime)Reader["Date"],
                    Address = Reader["Address"].ToString(),
                    DepartmentId = (int)Reader["DepartmentId"],
                    RegistrationNumber = Reader["Registrationno"].ToString(),
                    StdDepartmentName = Reader["DeptName"].ToString(),
                    StdDepartmentCode = Reader["DeptCode"].ToString(),
                };
                aStudents.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return aStudents;

        }
        
    }
    }
