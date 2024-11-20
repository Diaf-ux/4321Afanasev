using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _4321Afanasev.Models;

namespace _4321Afanasev.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            // Указываем имя таблицы
            builder.ToTable("Disciplines");

            // Настраиваем первичный ключ
            builder.HasKey(d => d.Id);

            // Свойства
            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("name");

            builder.Property(d => d.WorkloadHours)
                   .IsRequired()
                   .HasColumnName("workload_hours");

            // Связь с преподавателем
            builder.HasOne(d => d.Teacher) // У дисциплины один преподаватель
                   .WithMany(t => t.Disciplines) // У преподавателя много дисциплин
                   .HasForeignKey(d => d.TeacherId)
                   .OnDelete(DeleteBehavior.Cascade); // Удаление преподавателя удаляет дисциплины
        }
    }
}
