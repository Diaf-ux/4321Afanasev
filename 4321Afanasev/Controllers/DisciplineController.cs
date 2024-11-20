using Microsoft.AspNetCore.Mvc;
using _4321Afanasev.Interfaces;
using _4321Afanasev.Models;
using Microsoft.EntityFrameworkCore;

namespace _4321Afanasev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        private readonly IDisciplineService _disciplineService;

        public DisciplineController(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        [HttpGet("filter")]
        public IActionResult GetFilteredDisciplines(int? teacherId, int? minWorkload, int? maxWorkload)
        {
            var disciplines = _disciplineService.GetFilteredDisciplines(teacherId, minWorkload, maxWorkload);
            return Ok(disciplines);
        }

        [HttpPost("add")]
        public IActionResult AddDiscipline([FromBody] Discipline discipline)
        {
            if (discipline.TeacherId <= 0)
            {
                return BadRequest("TeacherId is required.");
            }

            // Не устанавливаем Teacher напрямую, используем только TeacherId
            _disciplineService.AddDiscipline(discipline);


            return Ok(discipline);
        }


        [HttpPut("update/{id}")]
        public IActionResult UpdateDiscipline(int id, [FromBody] Discipline discipline)
        {
            _disciplineService.UpdateDiscipline(id, discipline);
            return Ok("Discipline updated successfully");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteDiscipline(int id)
        {
            _disciplineService.DeleteDiscipline(id);
            return Ok("Discipline deleted successfully");
        }
    }
}
