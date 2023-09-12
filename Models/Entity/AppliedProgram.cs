using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechnoAcademyApi.Models.Entity
{
    public class AppliedProgram : BaseEntity
    {
        [Key]
        public string? UUID { get; set; } = Guid.NewGuid().ToString();
        public string? Last_Status { get; set; }

        [Required(ErrorMessage = "Program Entity not null")]
        [ForeignKey("ProgramEntity")]
        [JsonPropertyName("id_program_entity")]
        public string? IdProgramEntity { get; set; }
        public ProgramEntity? ProgramEntity { get; set; }

        [Required(ErrorMessage = "IDRegister not null")]
        [ForeignKey("FormRegister")]
        [JsonPropertyName("id_register")]
        public string? IdRegister { get; set; }
        public FormRegister? FormRegister { get; set; }
    }
}
