using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IBannerService
    {
        ResBase<BannerEntity> Create(BannerEntity entity);
        ResBase<BannerEntity>? Update(string uuid, BannerEntity entity);
        ResBase<BannerEntity>? Delete(string uuid);
        ResBase<List<BannerEntity>>? GetAll();
        ResBase<BannerEntity>? GetById(string uuid);
    }
}
