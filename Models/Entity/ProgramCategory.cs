using System.ComponentModel.DataAnnotations;

namespace TechnoAcademyApi.Models.Entity
{
    public class ProgramCategory : BaseEntity
    {
        [Key]
        public string? UUID { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Name not null")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Date start not null")]
        public DateTime? DateStart { get; set; }

        [Required(ErrorMessage = "Date end not null")]
        public DateTime? DateEnd { get; set; }
        public bool Flag { get; set; } = false;

    }
}
