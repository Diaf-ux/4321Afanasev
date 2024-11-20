namespace _4321Afanasev.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Обязательное свойство
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!; // Навигационное свойство
        public int WorkloadHours { get; set; }
    }


}
