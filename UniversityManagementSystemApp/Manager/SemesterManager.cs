using System.Collections.Generic;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class SemesterManager
    {
        SemesterGateway aSemesterGateway = new SemesterGateway();

        public List<Semester> GetAllSemester()
        {
            List<Semester> aSemesters = aSemesterGateway.GetAllSemester();
            return aSemesters;
        }
    }
}