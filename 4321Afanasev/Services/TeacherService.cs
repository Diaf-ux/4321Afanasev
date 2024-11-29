using _4321Afanasev.Models;
using _4321Afanasev.Filters;
using _4321Afanasev.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using _4321Afanasev.Database;

namespace _4321Afanasev.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly UniversityDbContext _context;

        public TeacherService(UniversityDbContext context)
        {
            _context = context;
        }

        public List<Teacher> GetTeachers(TeacherFilter filter)
        {
            var query = _context.Teachers.AsQueryable();

            // Выводим все данные до фильтрации
            Console.WriteLine("Teachers in the database before filter:");
            foreach (var teacher in query)
            {
                Console.WriteLine($"Name: {teacher.FirstName} {teacher.LastName}");
            }

            // Фильтрация по имени
            if (!string.IsNullOrEmpty(filter.FirstName))
            {
                query = query.Where(t => t.FirstName == filter.FirstName);
            }

            // Выводим количество преподавателей после фильтрации
            Console.WriteLine($"Teachers after filter: {query.Count()}");

            return query.Include(t => t.Department).Include(t => t.Disciplines).ToList();
        }
    }

}
