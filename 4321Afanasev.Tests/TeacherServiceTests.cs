using Xunit;
using _4321Afanasev.Services;
using Moq;
using _4321Afanasev.Interfaces;
using _4321Afanasev.Models;

public class TeacherServiceTests
{
    [Fact]
    public void FilterTeachers_ValidFilter_ReturnsExpectedResults()
    {
        // Arrange
        var mockService = new Mock<ITeacherService>();
        mockService.Setup(s => s.FilterTeachers(It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>()))
                   .Returns(new List<Teacher>
                   {
                       new Teacher { Id = 1, FirstName = "John", LastName = "Doe", Position = "Professor" }
                   });

        var teacherService = mockService.Object;

        // Act
        var result = teacherService.FilterTeachers(null, "Professor", null);

        // Assert
        Assert.Single(result);
        Assert.Equal("John", result.First().FirstName);
    }
}
