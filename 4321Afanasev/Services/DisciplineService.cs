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
    }
}
