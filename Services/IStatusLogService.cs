using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IStatusLogService
    {
        ResBase<StatusLog> Create(StatusLog statusLog);
        ResBase<StatusLog> Update(string uuid, StatusLog statusLog);
        ResBase<StatusLog> UpdatedReject(string uuid, StatusLog statusLog);
        ResBase<StatusLog> Delete(string uuid);
        ResBase<List<StatusLog>> GetAll();
        ResBase<StatusLog> GetByUUID(string uuid);
    }
}
