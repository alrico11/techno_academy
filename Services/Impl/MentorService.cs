using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class MentorService : IMentorService
    {
        private readonly ApplicationDbContext _context;

        public MentorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ResBase<MentorEntity> Create(MentorEntity entity)
        {
            try
            {
                _context.MentoryEntities.Add(entity);
                _context.SaveChanges();
                return new ResBase<MentorEntity> { Data = entity };
            }catch (Exception ex)
            {
                return new ResBase<MentorEntity>
                {
                    Success = false,
                    Code = 400,
                    Message = ex.Message,
                    Data = null
                };
            }
        }
        public ResBase<MentorEntity>? Delete(string uuid)
        {
            var data = _context.MentoryEntities.FirstOrDefault(x => x.UUID == uuid);
            if (data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
                return new ResBase<MentorEntity>
                {
                    Message = "Mentor Deleted",
                    Data = null,
                };
            }
            else
            {
                return null;
            }
        }
        public ResBase<List<MentorEntity>> GetAll()
        {
            var data = _context.MentoryEntities.ToList();
            return new ResBase<List<MentorEntity>>
            {
                Data = data
            };
        }

        public ResBase<MentorEntity>? GetByUUID(string uuid)
        {
            var data = _context.MentoryEntities.Find(uuid);
            if (data != null)
            {
                return new ResBase<MentorEntity>
                {
                    Data = data
                };
            }
            else
            {
                return null;
            }
        }

        public ResBase<MentorEntity>? Update(string uuid, MentorEntity entity)
        {
            var data = _context.MentoryEntities.Find(uuid);
            if (data != null)
            {
                data.Name = entity.Name;
                data.Photo = entity.Photo;
                data.Description = entity.Description;
                data.Framework = entity.Framework;
                data.Flag = entity.Flag;
                _context.SaveChanges();
                return new ResBase<MentorEntity> { Data = null };
            }
            else
            {
                return null;
            }
        }
    }
}
