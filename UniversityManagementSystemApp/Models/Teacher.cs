namespace UniversityManagementSystemApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contactno { get; set; }
        public int Designation_Id { get; set; }
        public int  Department_Id { get; set; }
        public decimal CreditToTake { get; set; }
        public decimal  Creditremain { get; set; }

    }
}