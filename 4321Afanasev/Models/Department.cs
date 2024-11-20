namespace _4321Afanasev.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Инициализация строки
        public int? HeadId { get; set; } // Заведующий кафедрой
        public Teacher? Head { get; set; } // Навигационное свойство, допускающее null
        public List<Teacher> Teachers { get; set; } = new(); // Инициализация пустого списка
    }
}
