using System;

namespace CourseManager.Application.DTOs
{
    public class CourseResponseDTO
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string? CourseDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
