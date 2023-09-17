using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IGCMEntityService
    {
        GCMEntity? Create(GCMEntity entity);
        GCMEntity? Update(string uuid,GCMEntity entity);
        GCMEntity? DeleteByUUID(string uuid);
        GCMEntity? Delete(string uuid);
        GCMEntity? GetByUUID(string uuid);
        ResGcmCondition? GetCondition();
        List<GCMEntity>? GetByCondition(string condition);
        List<GCMEntity> GetAll();

    }
}
