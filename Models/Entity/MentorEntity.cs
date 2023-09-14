using System.ComponentModel.DataAnnotations;

namespace TechnoAcademyApi.Models.Entity
{
    public class MentorEntity : BaseEntity
    {
        [Key]
        public string UUID { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Name not null")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Framework not null")]
        public string? Framework { get; set; }
        [Required(ErrorMessage = "Description not null")]
        public string? Description { get; set; }
        public string? Photo { get; set; }

    }
}
