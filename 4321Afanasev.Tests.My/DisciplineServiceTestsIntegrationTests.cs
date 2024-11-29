using Microsoft.EntityFrameworkCore;
using Xunit;
using _4321Afanasev.Database;
using _4321Afanasev.Models;
using _4321Afanasev.Services;
using System.Collections.Generic;
using System.Linq;

//Мы проверяем, что метод фильтрует дисциплины по кафедре (то есть по связи через преподавателей).
//Если в базе данных добавлены дисциплины, связанные с кафедрой, метод должен вернуть их корректно.

namespace _4321Afanasev.Tests
{
    public class DisciplineServiceTests
    {
        // Метод для создания настроек in-memory базы данных
        private DbContextOptions<UniversityDbContext> GetInMemoryOptions()
        {
            return new DbContextOptionsBuilder<UniversityDbContext>()
                .UseInMemoryDatabase("TestDatabase") // Указываем имя тестовой базы
                .Options;
        }


        [Fact]
        public async Task GetDisciplinesByDepartment_ShouldReturnCorrectCount()
        {
            // Arrange
            var options = GetInMemoryOptions();  // Получаем настройки базы данных

            // Создаем контекст базы данных с in-memory базой
            using var context = new UniversityDbContext(options);

            // Создаем сервис, который будет использовать in-memory базу данных
            var disciplineService = new DisciplineService(context);

            // Добавляем тестовые данные

            // Создаем кафедру
            var department = new Department { Id = 1, Name = "Mathematics" };

            // Создаем преподавателя и привязываем его к кафедре
            var teacher = new Teacher { Id = 1, FirstName = "Иван", LastName = "Иванов", DepartmentId = 1, Position = "Преподаватель", AcademicDegree = "Кандидат наук" };

            // Добавляем преподавателя и кафедру
            await context.Departments.AddAsync(department);
            await context.Teachers.AddAsync(teacher);

            // Создаем дисциплины и привязываем их к преподавателю
            var disciplines = new List<Discipline>
            {
                new Discipline { Name = "Algebra", TeacherId = 1, WorkloadHours = 40 },
                new Discipline { Name = "Geometry", TeacherId = 1, WorkloadHours = 45 }
            };

            // Добавляем дисциплины в контекст
            await context.Disciplines.AddRangeAsync(disciplines);
            await context.SaveChangesAsync();  // Сохраняем изменения в базе данных

            // Act
            // Вызываем метод сервиса, который должен вернуть дисциплины для преподавателя
            var result = await disciplineService.GetDisciplinesByDepartmentAsync(1);  // Метод, который мы тестируем

            // Assert
            // Проверяем, что количество дисциплин соответствует ожиданиям
            Assert.Equal(2, result.Count());
        }
    }
}
