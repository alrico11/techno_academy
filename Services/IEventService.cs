using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IEventService
    {
        ResBase<EventEntity>Create(EventEntity entity);
        ResBase<EventEntity>? Update(string uuid, EventEntity entity);
        ResBase<EventEntity>? Delete(string uuid);
        ResBase<EventEntity>? GetById(string uuid);
        ResBase<List<EventEntity>> GetAll();
    }
}
