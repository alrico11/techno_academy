using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoAcademyApi.Models.Entity
{
    public class ProgramEntity : BaseEntity
    {
        [Key]
        public string UUID { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Name not null")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Desc not null")]
        public string? Desc { get; set; }
        public bool StatusProgram { get; set; } = true;
        public bool Flag { get; set; } = false;
        [Required(ErrorMessage = "ID Program not null")]

        [ForeignKey("ProgramCategory")]
        public string? IdCategory { get; set; }
        [Required(ErrorMessage = "Pict not null")]
        public string? Pict { get; set; }
        public ProgramCategory? ProgramCategory { get; set; }
    }
}
