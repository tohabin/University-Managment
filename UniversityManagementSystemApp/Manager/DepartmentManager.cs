using System.Collections.Generic;
using UniversityManagementSystemApp.DAL.Gateway;
using UniversityManagementSystemApp.DAL.Model;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();

        public string Save(Department aDepartment)
        {

            if (aDepartmentGateway.IsExixt(aDepartment.Code))
            {
                int rowAffected = aDepartmentGateway.Save(aDepartment);
                if (rowAffected > 0)
                {
                    return "Deparment Save";
                }
                else
                {
                    return "Department Not Saved";
                }

            }
            else
            {
                return "Department Code alreay saved";
            }


        }



        public List<Department> GetAllDepartment()
        {
            List<Department> aDepartments = aDepartmentGateway.GetAllDepartment();
            return aDepartments;
        }
        public string GetAllDepartmentbyId(int deptId)
        {
            string aDepartments = aDepartmentGateway.GetAllDepartmentbyId(deptId);
            return aDepartments;
        }
    }
}