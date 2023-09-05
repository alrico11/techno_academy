using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Configuration;
using TechnoAcademyApi.Models.Dto.Req;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly string _secretKey;
        private readonly HashSet<string> _validTokens = new HashSet<string>();
        private readonly ApplicationDbContext _context;
        public AuthService(IOptions<AppSettings> appSettings, ApplicationDbContext context)
        {
            _secretKey = appSettings.Value.SecretKey;
            _context = context;
        }
        private bool IsValid(string email, string password)
        {
            var user = _context.UserEntities.FirstOrDefault(u => u.Email == email);

            if (user == null || user.Password != password)
            {
                return false;
            }

            return true;
        }

        public string GenerateToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Email, email)
        }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }



        public ResBase<TokenEntity> AuthLogin(Auth auth)
        {
            if (IsValid(auth.Email, auth.Password))
            {
                var token = GenerateToken(auth.Email);
                _validTokens.Add(token);

                // Mengakses data User
                var user = _context.UserEntities.FirstOrDefault(u => u.Email == auth.Email);

                var tokenEntity = new TokenEntity
                {
                    Token = token,
                    ExpiredToken = DateTime.UtcNow.AddDays(1),
                    UserId = user.UUID // Mengatur UserId dalam tokenEntity
                };
                _context.TokenEntities.Add(tokenEntity);
                _context.SaveChanges();
                return new ResBase<TokenEntity> { Data = tokenEntity };
            }
            return new ResBase<TokenEntity> { Success = false, Code = 401, Message = "Invalid Credentials", Data = null };
        }

        public ResBase<TokenEntity> AuthLogout(string token)
        {
            if (_validTokens.Contains(token))
            {
                _validTokens.Remove(token);
                return new ResBase<TokenEntity>
                {
                    Success = true,
                    Message = "Logout berhasil"
                };
            }

            return new ResBase<TokenEntity>
            {
                Success = false,
                Message = "Token tidak valid",
                Data = null,
                Code = 400
            };
        }
    }
}
