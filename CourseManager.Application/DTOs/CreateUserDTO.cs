using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Application.DTOs
{
    public class CreateUserDTO
    {
        [Required, MaxLength(100)]
        public string UserLogin { get; set; } = string.Empty;

        [Required, MaxLength(255)]
        public string UserPassword { get; set; } = string.Empty;

        [Required, StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
