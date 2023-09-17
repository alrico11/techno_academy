using System.ComponentModel.DataAnnotations;

namespace TechnoAcademyApi.Models.Entity
{
    public class FormRegister : BaseEntity
    {
        [Key]
        public string? UUID { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Name not null")]
        public string? Name { get; set; }
        [RegularExpression(@"^\d{10,13}$", ErrorMessage = "Invalid telephone number format.")]
        [Required(ErrorMessage = "Telephone not null")]
        public string? Telephone { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [Required(ErrorMessage = "Email not null")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "University not null")]
        public string? University { get; set; }
        [Required(ErrorMessage = "StudyProgram not null")]
        public string? StudyProgram { get; set; }
        [Required(ErrorMessage = "StudentStatus not null")]
        public bool StudentStatus { get; set; }
        [Required(ErrorMessage = "Semester not null")]
        public int Semester { get; set; }
        [Required(ErrorMessage = "IPK not null")]
        public float IPK { get; set; }
        [Required(ErrorMessage = "CV not null")]
        public string? CV { get; set; }
        [Required(ErrorMessage = "Domicile not null")]
        public string? Domicile { get; set; }
        [Required(ErrorMessage = "Photo not null")]
        public string? Photo { get; set; }
    }
}
