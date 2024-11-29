using Microsoft.AspNetCore.Mvc;
using _4321Afanasev.Interfaces;
using _4321Afanasev.Models;
using _4321Afanasev.Filters;

namespace _4321Afanasev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("filter")]
        public IActionResult GetTeachers([FromBody] TeacherFilter filter)
        {
            // Вызов сервиса с обновлённым фильтром
            var teachers = _teacherService.GetTeachers(filter);

            // Возвращаем результат (Ok 200)
            return Ok(teachers);
        }

        [HttpGet("search")]
        public IActionResult SearchTeachers([FromQuery] string? firstName, [FromQuery] string? lastName)
        {
            var result = _teacherService.GetTeachers(new TeacherFilter
            {
                FirstName = firstName,
                LastName = lastName
            });

            return Ok(result);
        }
    }
}
