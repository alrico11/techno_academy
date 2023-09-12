using System.ComponentModel.DataAnnotations;

namespace TechnoAcademyApi.Models.Entity
{
    public class GCMEntity : BaseEntity
    {
        [Key]
        public string UUID { get; set; } = Guid.NewGuid().ToString();
        public string? Condition { get; set; }
        public string? CharValue1 { get; set; }
        public string? CharDesc1 { get; set; }
        public string? CharValue2 { get; set; }
        public string? CharDesc2 { get; set; }
        public string? CharValue3 { get; set; }
        public string? CharDesc3 { get; set; }
        public string? CharValue4 { get; set; }
        public string? CharDesc4 { get; set; }
        public string? CharValue5 { get; set; }
        public string? CharDesc5 { get; set; }
        public string? Pict { get; set; }

        public int? Flag { get; set; } = 0;

        public static implicit operator GCMEntity(List<GCMEntity> v)
        {
            throw new NotImplementedException();
        }
    }
}
