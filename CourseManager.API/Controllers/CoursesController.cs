using CourseManager.Application.DTOs;
using CourseManager.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseResponseDTO>>> GetAll()
        {
            return Ok(await _courseService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseResponseDTO>> GetById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<CourseResponseDTO>> Create(CreateCourseDTO dto)
        {
            var course = await _courseService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCourseDTO dto)
        {
            var success = await _courseService.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _courseService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
