using _4321Afanasev.Database;
using _4321Afanasev.Interfaces;
using _4321Afanasev.Models;
using Microsoft.EntityFrameworkCore;

namespace _4321Afanasev.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly UniversityDbContext _context;

        public DisciplineService(UniversityDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Discipline> GetFilteredDisciplines(int? teacherId, int? minWorkload, int? maxWorkload)
        {
            var query = _context.Disciplines.AsQueryable();

            if (teacherId.HasValue)
                query = query.Where(d => d.TeacherId == teacherId.Value);



            if (minWorkload.HasValue)
                query = query.Where(d => d.WorkloadHours >= minWorkload.Value);

            if (maxWorkload.HasValue)
                query = query.Where(d => d.WorkloadHours <= maxWorkload.Value);

            return query.Include(d => d.Teacher).ToList();
        }

        // Новый метод для получения преподавателей по имени и фамилии
        public IEnumerable<Teacher> GetTeachersByName(string? firstName, string? lastName)
        {
            var query = _context.Teachers.AsQueryable();

            // Фильтрация по имени
            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(t => t.FirstName == firstName);

            // Фильтрация по фамилии
            if (!string.IsNullOrEmpty(lastName))
                query = query.Where(t => t.LastName == lastName);

            return query.Include(t => t.Department).Include(t => t.Disciplines).ToList();
        }


        public void AddDiscipline(Discipline discipline)
        {
            _context.Disciplines.Add(discipline);
            _context.SaveChanges();
        }

        public void UpdateDiscipline(int id, Discipline discipline)
        {
            var existing = _context.Disciplines.Find(id);
            if (existing == null) throw new ArgumentException("Discipline not found");

            existing.Name = discipline.Name;
            existing.TeacherId = discipline.TeacherId;
            existing.WorkloadHours = discipline.WorkloadHours;

            _context.SaveChanges();
        }

        public void DeleteDiscipline(int id)
        {
            var discipline = _context.Disciplines.Find(id);
            if (discipline == null) throw new ArgumentException("Discipline not found");

            _context.Disciplines.Remove(discipline);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Discipline>> GetDisciplinesByDepartmentAsync(int departmentId)
        {
            return await _context.Disciplines
                .Where(d => d.Teacher.DepartmentId == departmentId)  // Фильтруем дисциплины по кафедре преподавателя
                .Include(d => d.Teacher)  // Включаем данные о преподавателе
                .ToListAsync();
        }


    }
}
