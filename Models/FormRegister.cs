using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechnoAcademyApi.Models
{
    public class FormRegister : BaseEntity
    {
        [Key]
        public string? UUID { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage ="Nama not null")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Phone not null")]
        public string? Telephone { get; set; }

        [Required(ErrorMessage = "Email not null")]
        [EmailAddress(ErrorMessage = "Email tidak valid.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "University not null")]
        public string? University { get; set; }

        [Required(ErrorMessage = "study_program not null")]
        [JsonPropertyName("study_program")]
        public string? StudyProgram { get; set; }

        [Required(ErrorMessage = "student_status not null")]
        [JsonPropertyName("student_status")]
        public bool StudentStatus { get; set; }

        [Required(ErrorMessage = "Semester not null")]
        public int Semester { get; set; }

        [Required(ErrorMessage = "Ipk not null")]
        [JsonPropertyName("ipk")]
        public float IPK { get; set; }

        [Required(ErrorMessage = "Cv not null")]
        [JsonPropertyName("cv")]
        public string? CV { get; set; }

        [Required(ErrorMessage = "Domisili not null")]
        public string? Domicile { get; set; }

        //[Required(ErrorMessage = "Program category not null")]
        //[ForeignKey("ProgramCategory")]
        //[JsonPropertyName("id_program_category")]
        //public string[]? IdProgramCategory { get; set; }

        //[Required(ErrorMessage = "Program Entity not null")]
        //[ForeignKey("ProgramEntity")]
        //[JsonPropertyName("id_program_entity")]
        //public string[]? IdProgramEntity { get; set; }
    }
}
