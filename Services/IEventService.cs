using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IEventService
    {
        EventEntity? Create(EventEntity entity);
        EventEntity? Update(string uuid, EventEntity entity);
        EventEntity? Delete(string uuid);
        EventEntity? DeleteByUUID(string uuid);
        EventEntity? GetById(string uuid);
        List<EventEntity> GetAll();
    }
}
