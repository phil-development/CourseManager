using System.ComponentModel.DataAnnotations;

namespace CourseManager.Application.DTOs
{
    public class CreateUserCourseDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
