using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(UserEntity user);
    }
}
