using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class ViewResultManager
    {
        ViewResultGateway aViewResultGateway = new ViewResultGateway();

        public List<ViewResult> GetAllViewResults(int stdId)
        {

            List<ViewResult> allViewResults = aViewResultGateway.GetAllViewResults(stdId);
            return allViewResults;
        }
    }
}