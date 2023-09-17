using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IProgramCategoryService
    {
        ProgramCategory? Create(ProgramCategory programCategory);
        ProgramCategory? GetByUUID(string uuid);
        List<ProgramCategory> GetAll();
        ProgramCategory? Update(string uuid, ProgramCategory programCategory);
        ProgramCategory? DeleteByUUID(string uuid);
        ProgramCategory? Delete(string uuid);
    }
}
