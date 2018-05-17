using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class GradeGateway:Gateway
    {
        public List<Grade> GetAllGrades()
        {
            Query = "SELECT * FROM Grade WHERE GradeLetter <> 'NA'";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            List<Grade> allGrades = new List<Grade>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Grade aGrade = new Grade()
                {
                    Id = (int)Reader["Id"],
                    GradeLetter = Reader["GradeLetter"].ToString(),
                };
                allGrades.Add(aGrade);
            }
            Reader.Close();
            Connection.Close();
            return allGrades;


        }
    }
}