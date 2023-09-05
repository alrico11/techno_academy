using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IGalleryService
    {
        ResBase<GalleryEntity> Create(GalleryEntity entity);
        ResBase<GalleryEntity>? Update(string uuid, GalleryEntity entity);
        ResBase<GalleryEntity>? Delete(string uuid);
        ResBase<GalleryEntity>? GetById(string id);
        ResBase<List<GalleryEntity>> GetAll();
    }
}
