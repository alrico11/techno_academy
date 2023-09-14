using System.ComponentModel.DataAnnotations;

namespace TechnoAcademyApi.Models.Entity
{
    public class TestimonyEntity : BaseEntity
    {
        [Key]
        public string? UUID { get; set; } = Guid.NewGuid().ToString();
        
        [Required(ErrorMessage = "Photo Not Null")]
        public string? Photo { get; set; }
        
        [Required(ErrorMessage = "Name Not Null")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "Description Not Null")]
        public string? Description { get; set; }
    }
}
