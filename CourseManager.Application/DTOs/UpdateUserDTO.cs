using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Application.DTOs
{
    public class UpdateUserDTO
    {
        [Required, MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
