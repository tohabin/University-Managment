using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class ViewRoutineManager
    {
        ViewRoutineGateway aViewRoutineGateway = new ViewRoutineGateway();

        public List<ViewRoutine> GetAllViewCRoutines(int deptID)
        {

            List<ViewRoutine> aViewRoutines = aViewRoutineGateway.GetAllViewRoutines(deptID);
            return aViewRoutines;
        }
    }
}