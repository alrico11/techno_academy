using System.ComponentModel.DataAnnotations;

namespace TechnoAcademyApi.Models.Entity
{
    public class FormRegister : BaseEntity
    {
        [Key]
        public string? UUID { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? University { get; set; }
        public string? StudyProgram { get; set; }
        public bool StudentStatus { get; set; }
        public int Semester { get; set; }
        public float IPK { get; set; }
        public string? CV { get; set; }
        public string? Domicile { get; set; }
        public string? Photo { get; set; }
    }
}
