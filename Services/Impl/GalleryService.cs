using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class GalleryService : IGalleryService
    {
        private readonly ApplicationDbContext _context;
        public GalleryService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public ResBase<GalleryEntity> Create(GalleryEntity entity)
        {
            try
            {
                _context.GalleriesEntites.Add(entity);
                _context.SaveChanges();
                return new ResBase<GalleryEntity>
                {
                    Data = entity
                };
            }catch (Exception ex) {
                return new ResBase<GalleryEntity>
                {
                    Message = ex.Message,
                    Success = false,
                    Code = 400,
                    Data = null
                };
            }
        }

        public ResBase<GalleryEntity>? Delete(string uuid)
        {
           var data = _context.GalleriesEntites.Find(uuid);
           if (data == null) {
                return null;
           }
            _context.GalleriesEntites.Remove(data);
            _context.SaveChanges();
            return new ResBase<GalleryEntity>
            {
                Message = "Mentor Deleted",
                Data = null
            };
        }

        public ResBase<List<GalleryEntity>> GetAll()
        {
            var data = _context.GalleriesEntites.ToList();
            return new ResBase<List<GalleryEntity>>
            {
                Data = data
            };
        }

        public ResBase<GalleryEntity>? GetById(string id)
        {
            var data = _context.GalleriesEntites.Find(id);
            return data == null ? null : new ResBase<GalleryEntity> { Data = data };
        }

        public ResBase<GalleryEntity>? Update(string uuid, GalleryEntity entity)
        {
            var data = _context.GalleriesEntites.Find(uuid);
            if(data  == null)
            {
                return null;
            }
            data.Link = entity.Link;
            data.Flag = entity.Flag;
            _context.SaveChanges();
            return new ResBase<GalleryEntity> { Message = "Mentor Updated" };
        }
    }
}
