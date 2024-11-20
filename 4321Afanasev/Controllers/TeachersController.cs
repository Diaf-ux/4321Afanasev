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
            var teachers = _teacherService.GetTeachers(filter);
            return Ok(teachers);
        }
    }
}
