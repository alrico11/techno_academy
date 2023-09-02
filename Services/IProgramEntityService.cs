using TechnoAcademyApi.Models;

namespace TechnoAcademyApi.Services
{
    public interface IProgramEntityService
    {
        ResBase<ProgramEntity> Create(ProgramEntity programEntity);
        ResBase<ProgramEntity> Update(string uuid, ProgramEntity programEntity);
        ResBase<ProgramEntity> Delete(string uuid);
        ResBase<ProgramEntity> GetByUUID(string uuid);
        ResBase<List<ProgramEntity>> GetAll();
    }
}
