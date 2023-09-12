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

        public ResBase<BannerEntity> Create(BannerEntity entity)
        {
            try
            {
                _context.BannerEntities.Add(entity);
                _context.SaveChanges();
                return new ResBase<BannerEntity>
                {
                    Data = entity
                };
            }catch(Exception ex)
            {
                return new ResBase<BannerEntity> { Message = ex.Message, Data = null, Code = 400, Success = false };

            }
        }

        public ResBase<BannerEntity>? Delete(string uuid)
        {
            var data = _context.BannerEntities.Find(uuid);
            if (data == null)
            {
                return null;
            };
            _context.BannerEntities.Remove(data);
            _context.SaveChanges();
            return new ResBase<BannerEntity>
            {
                Message = "Banner Deleted"
            };
        }

        public ResBase<List<BannerEntity>>? GetAll()
        {
            var data = _context.BannerEntities.ToList();
            return new ResBase<List<BannerEntity>>
            {
                Data = data
            };
        }

        public ResBase<BannerEntity>? GetById(string uuid)
        {
            var data = _context.BannerEntities.Find(uuid);
            return data == null ? null : new ResBase<BannerEntity>
            {
                Data = data
            };
        }

        public ResBase<BannerEntity>? Update(string uuid, BannerEntity entity)
        {
            var data = _context.BannerEntities.Find(uuid);
            if(data == null)
            {
                return null;
            };
            data.Link = entity.Link;
            data.Flag = entity.Flag;
            _context.SaveChanges();
            return new ResBase<BannerEntity>
            {
                Message = "Banner Updated"
            };
        }
    }
}
