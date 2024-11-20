using _4321Afanasev.Models;
using Microsoft.EntityFrameworkCore;
using _4321Afanasev.Database.Configurations;

namespace _4321Afanasev.Database
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Discipline> Disciplines { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Применение конфигураций для каждой модели
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());

            base.OnModelCreating(modelBuilder); // Вызываем базовый метод для стандартного поведения
        }
    }
}
