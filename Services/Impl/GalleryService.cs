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
        
        public GalleryEntity? Create(GalleryEntity entity)
        {
            try
            {
                _context.Mst_gallery.Add(entity);
                _context.SaveChanges();
                return entity;
            }catch{
                return null;
            }
        }

        public GalleryEntity? Delete(string uuid)
        {
           var data = _context.Mst_gallery.Find(uuid);
           if (data == null) {
                return null;
           }
            _context.Mst_gallery.Remove(data);
            _context.SaveChanges();
            return data;
        }

        public List<GalleryEntity> GetAll()
        {
            var data = _context.Mst_gallery.Where(x => x.Flag_Active == true).ToList();
            return data;
        }

        public GalleryEntity? GetById(string id)
        {
            var data = _context.Mst_gallery.Find(id);
            return data == null ? null : data;
        }

        public GalleryEntity? Update(string uuid, GalleryEntity entity)
        {
            var data = _context.Mst_gallery.Find(uuid);
            if(data  == null)
            {
                return null;
            }
            data.Link = entity.Link;
            data.Flag_Active = entity.Flag_Active;
            _context.SaveChanges();
            return entity;
        }
    }
}
