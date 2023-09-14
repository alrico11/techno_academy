using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechnoAcademyApi.Models.Entity
{
    public class StatusLog : BaseEntity
    {
        [Key]
        public string? UUID { get; set; } = Guid.NewGuid().ToString();
        public string? Status { get; set; }
        public int? Sequence { get; set; }
        [Required(ErrorMessage = "Notes not null")]
        public string? Notes { get; set; }
        public string? StepStatus { get; set; }
        [ForeignKey("AppliedProgram")]
        [JsonPropertyName("id_applied_program")]
        public string? IdAppliedProgram { get; set; }
        public AppliedProgram? AppliedProgram { get; set; }
    }
}
