using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _4321Afanasev.Models;

namespace _4321Afanasev.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Указываем имя таблицы
            builder.ToTable("Departments");

            // Настраиваем первичный ключ
            builder.HasKey(d => d.Id);

            // Свойства
            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("name");

            // Связь с заведующим кафедрой
            builder.HasOne(d => d.Head) // Связь с одним преподавателем
                   .WithMany() // Нет коллекции со стороны преподавателя
                   .HasForeignKey(d => d.HeadId) // Внешний ключ - HeadId
                   .OnDelete(DeleteBehavior.Restrict); // Заведующего нельзя удалить, если он привязан к кафедре

            // Связь кафедры с преподавателями
            builder.HasMany(d => d.Teachers) // У кафедры много преподавателей
                   .WithOne(t => t.Department) // У преподавателя одна кафедра
                   .HasForeignKey(t => t.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade); // Удаление кафедры удаляет преподавателей
        }
    }
}
