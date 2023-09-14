using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IBannerService
    {
        BannerEntity? Create(BannerEntity entity);
        BannerEntity? Update(string uuid, BannerEntity entity);
        BannerEntity? Delete(string uuid);
        BannerEntity? GetById(string uuid);
        List<BannerEntity>? GetAll();
    }
}
