using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IAppliedProgramService
    {
        ResBase<AppliedProgram> Create(AppliedProgram appliedProgram);
        ResBase<AppliedProgram> GetByUUID(string uuid);
        ResBase<List<AppliedProgram>> GetAll();
        ResBase<AppliedProgram> Update(string uuid, AppliedProgram appliedProgram);
        ResBase<AppliedProgram> Delete(string uuid);

    }
}
