using System;

namespace CourseManager.Application.DTOs
{
    public class UserDetailResponseDTO
    {
        public int Id { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
