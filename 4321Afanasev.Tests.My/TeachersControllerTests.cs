using Moq;
using Xunit;
using _4321Afanasev.Services;
using _4321Afanasev.Models;
using _4321Afanasev.Database;
using _4321Afanasev.Filters;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using _4321Afanasev.Controllers;
using _4321Afanasev.Interfaces;
using Microsoft.AspNetCore.Mvc;

//���������������� ���������� �������������� �� �����.
//�� ���������, ��� ���������� ��������� ���������� ������ ��� ���������� ������ � ���������� �� � ��������� �������.
public class TeachersControllerTests
{
    [Fact]
    public void GetTeachers_ShouldReturnOkResult_WithFilteredTeachers()
    {
        // Arrange
        var mockService = new Mock<ITeacherService>();
        mockService.Setup(service => service.GetTeachers(It.IsAny<TeacherFilter>()))
            .Returns(new List<Teacher> { new Teacher { FirstName = "����" } });

        var controller = new TeachersController(mockService.Object);

        // Act
        var result = controller.GetTeachers(new TeacherFilter { FirstName = "����" });

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var teachers = Assert.IsType<List<Teacher>>(okResult.Value);
        Assert.Single(teachers);
        Assert.Equal("����", teachers.First().FirstName);
    }
}
