using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IUserService
    {
        ResBase<UserEntity> Create(UserEntity entity);
        ResBase<UserEntity>? Update(string uuid, UserEntity entity);
        ResBase<UserEntity>? Delete(string uuid);
        ResBase<UserEntity>? GetById(string uuid);
        ResBase<List<UserEntity>> GetAll();
    }
}
