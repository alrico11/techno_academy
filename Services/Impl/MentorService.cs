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
        public MentorEntity? Create(MentorEntity entity)
        {
            try
            {
                _context.Mst_mentor.Add(entity);
                _context.SaveChanges();
                return entity;
            }catch
            {
                return null;
            }
        }
        public MentorEntity? Delete(string uuid)
        {
            var data = _context.Mst_mentor.FirstOrDefault(x => x.UUID == uuid);
            if (data == null)
            {
                return null;
            }
            _context.Mst_mentor.Remove(data);
            _context.SaveChanges();
            return data;
        }
        public List<MentorEntity> GetAll()
        {
            var data = _context.Mst_mentor.Where(x => x.Flag_Active == true).ToList();
            return data;
        }

        public MentorEntity? GetByUUID(string uuid)
        {
            var data = _context.Mst_mentor.Find(uuid);
            return data == null ? null : data;
        }

        public MentorEntity? Update(string uuid, MentorEntity entity)
        {
            var data = _context.Mst_mentor.Find(uuid);
            if (data == null)
            {
                return null;   
            }
            data.Name = entity.Name;
            data.Photo = entity.Photo;
            data.Description = entity.Description;
            data.Framework = entity.Framework;
            data.Flag_Active = entity.Flag_Active;
            _context.SaveChanges();
            return data;
        }      
        public MentorEntity? DeleteByUUID(string uuid)
        {
            var data = _context.Mst_mentor.Find(uuid);
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
