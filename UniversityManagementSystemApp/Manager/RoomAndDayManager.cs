using System.Collections.Generic;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class RoomAndDayManager
    {
        RoomAndDayGateWay aRoomAndDayGateWay = new RoomAndDayGateWay();

        public List<Day> GetAllDay()
        {

            List<Day> aDays = aRoomAndDayGateWay.GetAllDay();
            return aDays;
        }

        public List<Room> GetAllRoom()
        {

            List<Room> aRooms = aRoomAndDayGateWay.GetAllRoom();
            return aRooms;
        }
        public string ClassroomUnassign()
        {

            int rowAfeected = aRoomAndDayGateWay.ClassroomUnassign();
            if (rowAfeected > 0)
            {
                return "Classroom Unassigned Successful";
            }
            else
            {
                return "Classroom Unassigned Unsuccessful";
            }

        }
    }
}