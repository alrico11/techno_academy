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
        public ResBase<TestimonyEntity> Create(TestimonyEntity entity)
        {
            _context.TestimonyEntities.Add(entity);
            _context.SaveChanges();
            return new ResBase<TestimonyEntity> { Data = entity };
        }

        public ResBase<TestimonyEntity>? Delete(string uuid)
        {
            var data = _context.TestimonyEntities.Find(uuid);
            if (data == null)
            {
                return null;
            };
            _context.TestimonyEntities.Remove(data);
            _context.SaveChanges();
            return new ResBase<TestimonyEntity> { Message = "Deleted Testimony" };
        }

        public ResBase<TestimonyEntity>? Get(string uuid)
        {
            var data = _context.TestimonyEntities.Find(uuid);
            return data == null ? null : new ResBase<TestimonyEntity> { Data = data };
        }

        public ResBase<List<TestimonyEntity>> GetAll()
        {
            var data = _context.TestimonyEntities.ToList();
            return new ResBase<List<TestimonyEntity>>
            { Data = data };
        }

        public ResBase<TestimonyEntity> Update(string uuid, TestimonyEntity entity)
        {
            var data = _context.TestimonyEntities.Find(uuid);
            if (data == null)
            {
                return null;
            }
            data.Name = entity.Name;
            data.Photo = entity.Photo;
            data.Description = entity.Description;
            _context.SaveChanges();
            return new ResBase<TestimonyEntity> { Message = "Testimony Updated" };

        }
    }
}
