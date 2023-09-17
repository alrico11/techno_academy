using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IStatusLogService
    {
        List<StatusLog> GetAll();
        StatusLog? GetByUUID(string uuid);
        List<StatusLog> GetStatusUserByEmail(string email);
        StatusLog? DeleteById(string uuid);
    }
}
