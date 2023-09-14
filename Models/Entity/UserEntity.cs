using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechnoAcademyApi.Models.Entity
{
    public class UserEntity : BaseEntity
    {
        [Key]
        public string? UUID { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public string? Password { get; set; }
        public string? Telephone { get; set; }
        [ForeignKey("RoleEntity")]
        public string? Role { get; set; }
        public RoleEntity? RoleEntity { get; set; }
    }
  }