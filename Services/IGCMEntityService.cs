using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IGCMEntityService
    {
        ResBase<GCMEntity> Create(GCMEntity entity);
        ResBase<GCMEntity>? Update(string uuid,GCMEntity entity);
        ResBase<GCMEntity> Delete(string uuid);
        ResBase<List<GCMEntity>> GetAll();
        ResBase<GCMEntity>? GetByUUID(string uuid);
        ResBase<List<GCMEntity>>? GetByCondition(string condition);
        ResBase<ResGcmCondition> GetCondition();
    }
}
