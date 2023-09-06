using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Models.Dto.Req
{
    public class AppliedDto
    {
        public string? UUID { get; set; } = Guid.NewGuid().ToString();
        public string? Last_Status { get; set; }

        [Required(ErrorMessage = "Program Entity not null")]
        [JsonPropertyName("id_program_entity")]
        public string[]? IdProgramEntity { get; set; }
        public ProgramEntity? ProgramEntity { get; set; }

        [ForeignKey("FormRegister")]
        [JsonPropertyName("id_register")]
        public string? IdRegister { get; set; }
        public FormRegister? FormRegister { get; set; }
    }
}
