using TechnoAcademyApi.Models.Dto.Req;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IAuthService
    {
        TokenEntity AuthLogin(Auth auth);
        TokenEntity AuthLogout(string token);
    }
}
