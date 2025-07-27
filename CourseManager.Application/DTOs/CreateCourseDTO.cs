using System.ComponentModel.DataAnnotations;

namespace CourseManager.Application.DTOs
{
    public class CreateCourseDTO
    {
        [Required, MaxLength(150)]
        public string CourseName { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? CourseDescription { get; set; }
    }
}
