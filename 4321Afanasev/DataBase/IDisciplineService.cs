using _4321Afanasev.Filters;
using _4321Afanasev.Models;

namespace _4321Afanasev.Interfaces
{
    public interface IDisciplineService
    {
        IEnumerable<Discipline> GetFilteredDisciplines(int? teacherId, int? minWorkload, int? maxWorkload);
        void AddDiscipline(Discipline discipline);
        void UpdateDiscipline(int id, Discipline discipline);
        void DeleteDiscipline(int id);
    }
}
