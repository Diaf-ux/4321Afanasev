using _4321Afanasev.Filters;
using _4321Afanasev.Models;

namespace _4321Afanasev.Interfaces
{
    public interface ITeacherService
    {
        List<Teacher> GetTeachers(TeacherFilter filter); // Метод для фильтрации преподавателей
    }
}
