using TechnoAcademyApi.Models.Dto.Req;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IAuthService
    {
        ResBase<TokenEntity> AuthLogin(Auth auth);
        ResBase<TokenEntity> AuthLogout(string token);
    }
}
