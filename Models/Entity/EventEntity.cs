using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechnoAcademyApi.Models.Entity
{
    public class EventEntity : BaseEntity
    {
        [Key]
        public string? UUID { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Name Not null")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Description Not null")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Photo Not null")]
        public string? Photo {get; set;}
        [JsonPropertyName("published_status")]
        public bool? PublishedStatus { get; set; } = true;
        public int? Flag { get; set; } = 0;
    }
}
