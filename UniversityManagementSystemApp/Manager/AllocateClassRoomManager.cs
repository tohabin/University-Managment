using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class AllocateClassRoomManager
    {
        AllocateClassRoomGateway allocateClassRoomGateway =new AllocateClassRoomGateway();

        public string SaveAlocateClassRoom(AllocateClassRoom allocateClassRoom)
        {
            if (allocateClassRoom.DateTimeFrom.TimeOfDay< allocateClassRoom.DateTimeTo.TimeOfDay)
            {
                allocateClassRoom.DateTimeTo = allocateClassRoom.DateTimeTo.AddMinutes(-1);
                int rowCount = allocateClassRoomGateway.IsRoomFree(allocateClassRoom.RoomId, allocateClassRoom.DateTimeFrom,
               allocateClassRoom.DateTimeTo, allocateClassRoom.DayId);
                if (rowCount == 0)
                {
                    int rowAffected = allocateClassRoomGateway.SaveAlocateClassRoom(allocateClassRoom);
                    if (rowAffected > 0)
                    {
                        return " Class Room Allocated sucessfully";
                    }
                    else
                    {
                        return "Class Room not allocated";
                    }

                }
                else
                {
                    return "Class room is not free";
                }
                
            }
            else
            {
                return "Pls select Class Duration carefully";
            }
           
           
        }
    }
}