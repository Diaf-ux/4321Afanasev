namespace _4321Afanasev.Filters
{
    public class TeacherFilter
    {
        public string? DepartmentName { get; set; } // Фильтрация по названию кафедры
        public string? AcademicDegree { get; set; } // Фильтрация по степени
        public string? Position { get; set; } // Фильтрация по должности

        public string? FirstName { get; set; } // Фильтрация по имени
        public string? LastName { get; set; } // Фильтрация по фамилии
    }
}
