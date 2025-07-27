using System;
using System.Collections.Generic;

namespace CourseManager.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string? CourseDescription { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // 🔗 Relacionamentos
        public ICollection<UserCourse>? UserCourses { get; set; }
    }
}
