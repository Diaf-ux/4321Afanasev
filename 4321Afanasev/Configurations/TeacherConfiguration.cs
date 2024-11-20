using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _4321Afanasev.Models;

namespace _4321Afanasev.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            // Указываем имя таблицы
            builder.ToTable("Teachers");

            // Настраиваем первичный ключ
            builder.HasKey(t => t.Id);

            // Свойства
            builder.Property(t => t.FirstName)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("first_name");

            builder.Property(t => t.LastName)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("last_name");

            // Связь с кафедрой
            builder.HasOne(t => t.Department) // У преподавателя одна кафедра
                   .WithMany(d => d.Teachers) // У кафедры много преподавателей
                   .HasForeignKey(t => t.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade); // Удаление кафедры удаляет преподавателей
        }
    }
}
