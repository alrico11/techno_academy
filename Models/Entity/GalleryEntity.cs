using System.ComponentModel.DataAnnotations;

namespace TechnoAcademyApi.Models.Entity
{
    public class GalleryEntity : BaseEntity
    {
        [Key]
        public string? UUID { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Link not null")]
        public string? Link { get; set; }
    }
}
