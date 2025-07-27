using System;

namespace CourseManager.Domain.Entities
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // 🔗 Relacionamento
        public User User { get; set; }
    }
}
