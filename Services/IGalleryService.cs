using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IGalleryService
    {    
        GalleryEntity? Create(GalleryEntity entity);
        GalleryEntity? Update(string uuid, GalleryEntity entity);
        GalleryEntity? Delete(string uuid);
        GalleryEntity? DeleteByUUID(string uuid);
        GalleryEntity? GetById(string id);
        List<GalleryEntity> GetAll();
    }
}
