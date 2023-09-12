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

        public ResBase<EventEntity> Create(EventEntity entity)
        {
            _context.EventEntities.Add(entity);
            _context.SaveChanges();
            return new ResBase<EventEntity>
            {
                Data = entity
            };
        }

        public ResBase<EventEntity>? Delete(string uuid)
        {
            var data = _context.EventEntities.Find(uuid);
            if (data == null)
            {
                return null;
            };
            _context.EventEntities.Remove(data);
            _context.SaveChanges();
            return new ResBase<EventEntity> { Message = "Event Deleted" };
        }

        public ResBase<List<EventEntity>> GetAll()
        {
            var data = _context.EventEntities.ToList();
            return new ResBase<List<EventEntity>> { Data = data };
        }

        public ResBase<EventEntity>? GetById(string uuid)
        {
            var data = _context.EventEntities.Find(uuid);
            return (data == null) ? null : new ResBase<EventEntity> {  Data = data };
        }

        public ResBase<EventEntity>? Update(string uuid, EventEntity entity)
        {
            var data = _context.EventEntities.Find(uuid);
            if (data == null)
            {
                return null;
            }
            data.Name = entity.Name;
            data.Photo = entity.Photo;
            data.Description = entity.Description;
            data.Flag = entity.Flag;
            data.PublishedStatus = entity.PublishedStatus;
            _context.SaveChanges();
            return new ResBase<EventEntity>
            {
                Message = "Event Updated"
            };
        }
    }
}
