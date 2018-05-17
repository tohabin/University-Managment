namespace UniversityManagementSystemApp.Models
{
    public class AssignCourse
    {
        public int Id { get; set; }
        public int Department_Id { get; set; }
        public int Teacher_Id { get; set; }
        public int Course_Id { get; set; }
        public decimal Creditremain { get; set; }
        public decimal Credit { get; set; }

        public int Status_Id { get; set; }
        

    }
}