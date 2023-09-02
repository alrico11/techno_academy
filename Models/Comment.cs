using System.ComponentModel.DataAnnotations;

namespace TechnoAcademyApi.Models
{
    public class Comment : BaseEntity
    {
        [Key]
       
        public string UUID { get; set; } =  Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Name not null")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email not null")]
        [EmailAddress(ErrorMessage = "Email not valid")]
        public string? Email { get; set; }
        public string? Parent_Comment { get; set; }
        [Required(ErrorMessage = "Content not null")]
        public string? Content { get; set; }
    }
}
