using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class ViewRoutineGateway:Gateway
    {
        public List<ViewRoutine> GetAllViewRoutines(int deptId)
        {

            Query = "SELECT Course.Code, Course.Name as CourseName,Room.Name as RoomName,Day.Name as Day, AllocateClassRoom.DateFrom, AllocateClassRoom.DateTo FROM Course Left JOIN AllocateClassRoom ON Course.id=AllocateClassRoom.CourseId LEFT JOIN Room ON AllocateClassRoom.RoomId=Room.id LEFT JOIN Day ON AllocateClassRoom.DayId=Day.Id WHERE Course.Department_Id='"+deptId+"'";
            Command = new SqlCommand(Query, Connection);
            List<ViewRoutine> aViewRoutineList = new List<ViewRoutine>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ViewRoutine aViewRoutine = new ViewRoutine
                {

                    CourseCode = Reader["Code"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    RoomName = Reader["RoomName"].ToString(),
                    Day = Reader["Day"].ToString(),
                    StarTime =  Reader["DateFrom"].ToString(),
                    EndTime = Reader["DateTo"].ToString()
                };
                aViewRoutineList.Add(aViewRoutine);
            }
            Reader.Close();
            Connection.Close();
            return aViewRoutineList;


        }
    }
}