using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IProgramCategoryService
    {
        ResBase<ProgramCategory> Create(ProgramCategory programCategory);
        ResBase<ProgramCategory> GetByUUID(string uuid);
        ResBase<List<ProgramCategory>> GetAll();
        ResBase<ProgramCategory> Update(string uuid, ProgramCategory programCategory);
        ResBase<ProgramCategory> Delete(string uuid);
    }
}
