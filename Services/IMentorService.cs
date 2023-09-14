using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IMentorService
    {
        MentorEntity? Create(MentorEntity entity);
        MentorEntity? Update(string uuid,MentorEntity entity);
        MentorEntity? Delete(string uuid);
        MentorEntity? GetByUUID(string uuid);
        List<MentorEntity>? GetAll();
    }
}
