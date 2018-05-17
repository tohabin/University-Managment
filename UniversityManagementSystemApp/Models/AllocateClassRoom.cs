using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagementSystemApp.Models
{
    public class AllocateClassRoom
    {

        public int Id { get; set; }
        public int DepartmentId { get; set; }
        
        public int CourseId { get; set; }
        
        public int RoomId { get; set; }
        
        public int DayId { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }

    }
}