using System.ComponentModel.DataAnnotations;

namespace CourseManager.Application.DTOs
{
    public class UpdateUserDetailDTO
    {
        [MaxLength(255)]
        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }
    }
}
