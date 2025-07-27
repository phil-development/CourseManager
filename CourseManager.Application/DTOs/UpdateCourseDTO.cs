using System.ComponentModel.DataAnnotations;

namespace CourseManager.Application.DTOs
{
    public class UpdateCourseDTO
    {
        [Required, MaxLength(150)]
        public string CourseName { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? CourseDescription { get; set; }
    }
}
