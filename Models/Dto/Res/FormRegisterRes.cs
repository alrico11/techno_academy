using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TechnoAcademyApi.Models.Dto.Res
{
    public class FormRegisterRes
    {
        public string? Name { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? University { get; set; }
        public string? StudyProgram { get; set; }
        [JsonPropertyName("student_status")]
        public bool StudentStatus { get; set; }
        public int Semester { get; set; }
        [JsonPropertyName("ipk")]
        public float IPK { get; set; }
        [JsonPropertyName("cv")]
        public string? CV { get; set; }
        public string? Domicile { get; set; }
        public string? Photo { get; set; }
    }
}
