using System;

namespace CourseManager.Domain.Entities
{
    public class UserCourse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // 🔗 Relacionamentos
        public User User { get; set; }
        public Course Course { get; set; }
    }
}
