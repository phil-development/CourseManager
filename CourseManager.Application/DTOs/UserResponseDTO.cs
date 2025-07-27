using System;

namespace CourseManager.Application.DTOs
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string UserLogin { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
