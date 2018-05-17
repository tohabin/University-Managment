using System.Collections.Generic;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class StudentManager
    {
      StudentGateway aStudentGateway = new StudentGateway();
        public string SaveStudent(Student aStudent)
        {
            if (aStudentGateway.IsEmailExixt(aStudent.Email))
            {
                int rowAfeected = aStudentGateway.SaveStudent(aStudent);
                if (rowAfeected > 0)
                {
                    return aStudent.RegistrationNumber+ "    Student Saved";
                }
                else
                {
                    return "Student not Saved";
                }
            }
            else
            {
                return "Email Aready Saved";
            }
        }

        public int GetRowCount(string regno)
        {
            int count = aStudentGateway.GetRowCount(regno);
            return count;
        }
        public List<Student> GetAllStudents()
        {
            List<Student> aStudents = aStudentGateway.GetAllStudents();
            return aStudents;
        }
       
    }
}