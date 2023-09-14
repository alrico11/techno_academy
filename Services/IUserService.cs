using TechnoAcademyApi.Models.Dto.Req;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IUserService
    {
        UserCmsReq? Create(UserCmsReq entity);
        UserEntity? Update(string uuid, UserEntity entity);
        UserEntity? Delete(string uuid);
        UserEntity? GetById(string uuid);
        List<UserCmsRes> GetAll();
    }
}
