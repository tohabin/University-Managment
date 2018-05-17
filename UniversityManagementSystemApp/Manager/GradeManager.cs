using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class GradeManager
    {
        GradeGateway aGradeGateway = new GradeGateway();
        public List<Grade> GetAllGrades()
        {

            List<Grade> allGrades = aGradeGateway.GetAllGrades();
            return allGrades;
        }
    }
}