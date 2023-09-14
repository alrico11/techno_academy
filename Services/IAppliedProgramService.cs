using TechnoAcademyApi.Models.Dto.Req;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IAppliedProgramService
    {
        AppliedProgram? Create(AppliedDto appliedProgram);
        AppliedProgram? GetByUUID(string uuid);
        List<AppliedProgram> GetAll();
        AppliedProgram? Update(string uuid, AppliedProgram appliedProgram);
        AppliedProgram? Delete(string uuid);
        AppliedProgram? UpdateStatus(string uuid, UpdateStatusReq updateStatusReq);
    }
}
