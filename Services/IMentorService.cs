using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IMentorService
    {
        ResBase<MentorEntity>? Create(MentorEntity entity);
        ResBase<MentorEntity>? Update(string uuid,MentorEntity entity);
        ResBase<MentorEntity>? Delete(string uuid);
        ResBase<MentorEntity>? GetByUUID(string uuid);
        ResBase<List<MentorEntity>>? GetAll();
    }
}
