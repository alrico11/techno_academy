
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnoAcademyApi.Models
{
    public class FormRegister
    {
        [Key]
        public string UUID { get; set; }
        public string Nama { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Universitas { get; set; }
        public string Prodi { get; set; }
        public bool StatusMahasiswa { get; set; }
        public int Semester { get; set; }
        public float Ipk { get; set; }
        public string Cv { get; set; }
        [NotMapped]
        public string[] ProgramFreelance { get; set; }

    }
}
