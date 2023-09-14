using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class BannerService : IBannerService
    {
        private readonly ApplicationDbContext _context;

        public BannerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public BannerEntity? Create(BannerEntity entity)
        {
            try
            {
                _context.Mst_banner.Add(entity);
                _context.SaveChanges();
                return entity;
            }catch
            {
                return null;
            }
        }
        public BannerEntity? Delete(string uuid)
        {
            var data = _context.Mst_banner.Find(uuid);
            if (data == null)
            {
                return null;
            };
            _context.Mst_banner.Remove(data);
            _context.SaveChanges();
            return data;
        }

        public List<BannerEntity>? GetAll()
        {
            var data = _context.Mst_banner
                        .Where(x => x.Flag_Active == true)
                        .ToList();
            return data;
        }

        public BannerEntity? GetById(string uuid)
        {
            var data = _context.Mst_banner.Find(uuid);
            return data == null ? null : data;
        }

        public BannerEntity? Update(string uuid, BannerEntity entity)
        {
            var data = _context.Mst_banner.Find(uuid);
            if(data == null)
            {
                return null;
            };
            data.Link = entity.Link;
            data.Flag_Active = entity.Flag_Active;
            _context.SaveChanges();
            return data;
        }
    }
}
