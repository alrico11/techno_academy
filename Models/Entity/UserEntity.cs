using System.ComponentModel.DataAnnotations;

namespace TechnoAcademyApi.Models.Entity
{
    public class UserEntity : BaseEntity
    {
        [Key]
        public string? UUID { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Telephone { get; set; }
        public string? Role { get; set; }
        public int? Flag { get; set; } = 0;
    }
}