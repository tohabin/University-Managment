using System;

namespace UniversityManagementSystemApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contactno { get; set; }
        public DateTime RegistrationDate { get; set; }
        
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string RegistrationNumber { get; set; }
        public string StdDepartmentName { get; set; }
        public string StdDepartmentCode { get; set; }
    }
}