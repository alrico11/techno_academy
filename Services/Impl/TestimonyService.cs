using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class TestimonyService : ITestimonyService
    {
        private readonly ApplicationDbContext _context;
        public TestimonyService(ApplicationDbContext context)
        {
            _context = context;
        }
        public TestimonyEntity? Create(TestimonyEntity entity)
        {
            try
            {
                _context.Mst_testimony.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch
            {
                return null;
            }
        }

        public TestimonyEntity? Delete(string uuid)
        {
            var data = _context.Mst_testimony.Find(uuid);
            if (data == null)
            {
                return null;
            };
            _context.Mst_testimony.Remove(data);
            _context.SaveChanges();
            return data;
        }

        public TestimonyEntity? Get(string uuid)
        {
            var data = _context.Mst_testimony.Find(uuid);
            return data == null ? null : data;
        }

        public List<TestimonyEntity> GetAll()
        {
            var data = _context.Mst_testimony.Where(x => x.Flag_Active == true)
                        .ToList();
            return data;
        }

        public TestimonyEntity? Update(string uuid, TestimonyEntity entity)
        {
            var data = _context.Mst_testimony.Find(uuid);
            if (data == null)
            {
                return null;
            }
            data.Name = entity.Name;
            data.Photo = entity.Photo;
            data.Description = entity.Description;
            data.Rating = entity.Rating;
            data.Flag_Active = entity.Flag_Active;
            _context.SaveChanges();
            return entity;
        }
        public TestimonyEntity? DeleteById(string uuid)
        {
            var data = _context.Mst_testimony.Find(uuid);
            if (data == null)
            {
                return null;
            }
            data.Flag_Active = false;
            _context.SaveChanges();
            return data;
        }
    }
}
