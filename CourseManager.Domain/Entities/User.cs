using System;
using System.Collections.Generic;

namespace CourseManager.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserLogin { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // 🔗 Relacionamentos
        public UserDetail? UserDetail { get; set; }
        public ICollection<UserCourse>? UserCourses { get; set; }
    }
}
