using System.ComponentModel.DataAnnotations;

namespace CourseManager.Application.DTOs
{
    public class CreateUserDetailDTO
    {
        [Required, StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; } = string.Empty;

        [MaxLength(255)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }
    }
}
