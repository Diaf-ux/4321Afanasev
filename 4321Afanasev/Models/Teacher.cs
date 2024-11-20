namespace _4321Afanasev.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int DepartmentId { get; set; } // Внешний ключ на кафедру
        public Department Department { get; set; } = null!; // Навигационное свойство
        public List<Discipline> Disciplines { get; set; } = new();

        // Добавляем недостающие свойства
        public string Position { get; set; } = string.Empty; // Должность
        public string AcademicDegree { get; set; } = string.Empty; // Учёная степень
    }
}
