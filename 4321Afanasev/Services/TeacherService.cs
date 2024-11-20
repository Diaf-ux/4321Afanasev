using _4321Afanasev.Database;
using _4321Afanasev.Filters;
using _4321Afanasev.Interfaces;
using _4321Afanasev.Models;

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

            // Фильтр по кафедре
            if (!string.IsNullOrEmpty(filter.DepartmentName))
            {
                query = query.Where(t => t.Department.Name == filter.DepartmentName);
            }

            // Фильтр по академической степени
            if (!string.IsNullOrEmpty(filter.AcademicDegree))
            {
                query = query.Where(t => t.AcademicDegree == filter.AcademicDegree);
            }

            // Фильтр по должности
            if (!string.IsNullOrEmpty(filter.Position))
            {
                query = query.Where(t => t.Position == filter.Position);
            }

            return query.ToList();
        }
    }
}
