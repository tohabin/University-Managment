using System.Collections.Generic;
using System.Data.SqlClient;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Gateway
{
    public class RoomAndDayGateWay:Gateway
    {
        public List<Day> GetAllDay()
        {
            Query = "SELECT * From Day";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
           List<Day> aDays = new List<Day>(); 
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Day aDay= new Day()
                {
                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString()
                };
                aDays.Add(aDay);
            }
            Reader.Close();
            Connection.Close();

            return aDays;

        }

        public List<Room> GetAllRoom()
        {
            Query = "SELECT * From Room";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
           List<Room> aRooms = new List<Room>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Room aRoom = new Room()
                {
                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString()
                };
                aRooms.Add(aRoom);
            }
            Reader.Close();
            Connection.Close();

            return aRooms;
            
        }

        public int ClassroomUnassign()
        {
            Query = "UPDATE AllocateClassRoom SET StatusId=0";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}