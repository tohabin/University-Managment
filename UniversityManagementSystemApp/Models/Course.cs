﻿namespace UniversityManagementSystemApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Credit { get; set; }
        public string Description { get; set; }
        public int Department_Id { get; set; }
        public int Semester_Id { get; set; }


    }
}