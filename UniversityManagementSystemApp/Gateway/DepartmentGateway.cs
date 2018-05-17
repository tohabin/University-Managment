using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class DepartmentGateway : Gateway
    {
        public bool IsExixt(string code)
        {
            Query = "SELECT * FROM Department WHERE Code='" + code + "'";
            Connection.Open();
            Command = new SqlCommand(Query,Connection);
            Reader = Command.ExecuteReader();
            bool isexixt;
            if (Reader.HasRows)
            {
               isexixt= false;
            }
            else
            {
                isexixt= true;
            }
            Reader.Close();
            Connection.Close();
            return isexixt;


        }

        public int Save(Department aDepartment)
        {
            Query = "INSERT INTO Department(Code,Name) Values(@Code,@Name)";
            Connection.Open();
            Command = new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("Code", SqlDbType.VarChar);
            Command.Parameters["Code"].Value = aDepartment.Code;
            Command.Parameters.Add("Name", SqlDbType.VarChar);
            Command.Parameters["Name"].Value = aDepartment.Name;
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }

        public List<Department> GetAllDepartment()
        {
            Query = "SELECT * FROM Department";
            Connection.Open();
            Command = new SqlCommand(Query,Connection);
            List<Department> aDepartments = new List<Department>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Department aDepartment = new Department()
                {
                    Id = (int) Reader["Id"],
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString()

                };
                aDepartments.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return aDepartments;
        }
        public string GetAllDepartmentbyId(int deptId)
        {
            string deptCode = null;
            Query = "SELECT Code FROM Department WHERE Id = '" + deptId + "'";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {

                deptCode = Reader["Code"].ToString();

            }
            Reader.Close();
            Connection.Close();
            return deptCode;

        }
    }
}