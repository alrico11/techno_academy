using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechnoAcademyApi.Models.Entity
{
    public class TokenEntity : BaseEntity
    {
        [Key]
        public string? UUID { get; set; } = Guid.NewGuid().ToString();
        public string? Token { get; set;}

        public string? UserId { get; set; }
        [JsonPropertyName("expired_token")]
        public DateTime ExpiredToken { get; set; }
    }
}
