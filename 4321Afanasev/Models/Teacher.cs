namespace _4321Afanasev.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public List<Discipline> Disciplines { get; set; } = new();
    }

}
