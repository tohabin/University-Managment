﻿using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class SemesterGateway :Gateway
    {
        public List<Semester> GetAllSemester()
        {
            Query = "SELECT * FROM Semester";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            List<Semester> aSemesters =new List<Semester>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Semester aSemester = new Semester()
                {
                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString()
                };
                aSemesters.Add(aSemester);
            }
            Reader.Close();
            Connection.Close();
            return aSemesters;
        }
    }
}