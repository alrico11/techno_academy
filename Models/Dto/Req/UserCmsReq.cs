using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Models.Dto.Req
{
    public class UserCmsReq
    {
        public string? UUID { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Telephone { get; set; }
        [ForeignKey("RoleEntity")]
        public string? Role { get; set; }
        public RoleEntity? RoleEntity { get; set; }
    }
}
