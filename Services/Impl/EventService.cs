using Org.BouncyCastle.Asn1.Cms;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public EventEntity Create(EventEntity entity)
        {
            _context.Mst_event.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public EventEntity? Delete(string uuid)
        {
            var data = _context.Mst_event.Find(uuid);
            if (data == null)
            {
                return null;
            };
            _context.Mst_event.Remove(data);
            _context.SaveChanges();
            return data;
        }

        public List<EventEntity> GetAll()
        {
            var data = _context.Mst_event.Where(x => x.Flag_Active == true)
                        .ToList();
            return data;
        }

        public EventEntity? GetById(string uuid)
        {
            var data = _context.Mst_event.Find(uuid);
            return data == null ? null : data;
        }

        public EventEntity? Update(string uuid, EventEntity entity)
        {
            var data = _context.Mst_event.Find(uuid);
            if (data == null)
            {
                return null;
            }
            data.Name = entity.Name;
            data.Photo = entity.Photo;
            data.Description = entity.Description;
            data.PublishedStatus = entity.PublishedStatus;
            data.Flag_Active = entity.Flag_Active;
            _context.SaveChanges();
            return data;
        }
        public EventEntity? DeleteByUUID(string uuid)
        {
            var data = _context.Mst_event.Find(uuid);
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
