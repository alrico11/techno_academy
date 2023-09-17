using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IProgramEntityService
    {
        ProgramEntity? Create(ProgramEntity programEntity);
        ProgramEntity? Update(string uuid, ProgramEntity programEntity);
        ProgramEntity? Delete(string uuid);
        ProgramEntity? GetByUUID(string uuid);
        List<ProgramEntity> GetAll();
        ProgramEntity? DeleteByUUID(string uuid);
    }
}
