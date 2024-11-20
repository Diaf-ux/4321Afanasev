using System.Text.Json.Serialization;

namespace _4321Afanasev.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Обязательное свойство
        public int TeacherId { get; set; }
        [JsonIgnore] // Игнорирование навигационного свойства
        public Teacher? Teacher { get; set; } = null!;
        public int WorkloadHours { get; set; }
    }


}
