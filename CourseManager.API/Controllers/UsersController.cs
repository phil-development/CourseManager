using CourseManager.Application.DTOs;
using CourseManager.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserDetailService _userDetailService;
        private readonly IUserCourseService _userCourseService;

        public UsersController(
            IUserService userService,
            IUserDetailService userDetailService,
            IUserCourseService userCourseService)
        {
            _userService = userService;
            _userDetailService = userDetailService;
            _userCourseService = userCourseService;
        }

        // ========== USERS ==========
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetAll() =>
            Ok(await _userService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDTO>> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDTO>> Create(CreateUserDTO dto)
        {
            var user = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserDTO dto)
        {
            var success = await _userService.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _userService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        // ========== USER DETAILS ==========
        [HttpGet("{userId}/details")]
        public async Task<ActionResult<UserDetailResponseDTO>> GetDetails(int userId)
        {
            var details = await _userDetailService.GetByIdAsync(userId);
            if (details == null) return NotFound();
            return Ok(details);
        }

        [HttpPost("{userId}/details")]
        public async Task<ActionResult<UserDetailResponseDTO>> CreateDetails(int userId, CreateUserDetailDTO dto)
        {
            // Garante que o CPF corresponda ao do usuário
            if (string.IsNullOrEmpty(dto.CPF))
            {
                var user = await _userService.GetByIdAsync(userId);
                if (user == null) return NotFound("Usuário não encontrado.");
                dto.CPF = user.CPF;
            }

            var details = await _userDetailService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetDetails), new { userId = details.Id }, details);
        }

        [HttpPut("{userId}/details")]
        public async Task<IActionResult> UpdateDetails(int userId, UpdateUserDetailDTO dto)
        {
            var success = await _userDetailService.UpdateAsync(userId, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        // ========== USER COURSES ==========
        [HttpGet("{userId}/courses")]
        public async Task<ActionResult<IEnumerable<UserCourseResponseDTO>>> GetUserCourses(int userId)
        {
            var courses = await _userCourseService.GetAllAsync();
            return Ok(courses.Where(c => c.UserId == userId));
        }

        [HttpPost("{userId}/courses")]
        public async Task<ActionResult<UserCourseResponseDTO>> AddCourse(int userId, CreateUserCourseDTO dto)
        {
            dto.UserId = userId;
            var userCourse = await _userCourseService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetUserCourses), new { userId = dto.UserId }, userCourse);
        }

        [HttpDelete("{userId}/courses/{courseId}")]
        public async Task<IActionResult> RemoveCourse(int userId, int courseId)
        {
            var courses = await _userCourseService.GetAllAsync();
            var uc = courses.FirstOrDefault(x => x.UserId == userId && x.CourseId == courseId);

            if (uc == null) return NotFound();

            var success = await _userCourseService.DeleteAsync(uc.Id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
