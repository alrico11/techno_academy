using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Req;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;
using TechnoAcademyApi.Utils;

namespace TechnoAcademyApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly ApplicationDbContext _context;

        public AuthService(IConfiguration configuration, IJwtTokenService jwtTokenService, ApplicationDbContext context)
        {
            _configuration = configuration;
            _jwtTokenService = jwtTokenService;
            _context = context;
        }

        public TokenEntity AuthLogin(Auth auth)
        {
            if (string.IsNullOrEmpty(auth.Email) || string.IsNullOrEmpty(auth.Password))
            {
                return null;
            }

            var user = _context.Mst_user_cms.SingleOrDefault(u => u.Email == auth.Email);
            if (user == null)
            {
                return null;
            }

            var encryptedPassword = PasswordHelper.EncryptPassword(auth.Password);
            if (user.Password != encryptedPassword)
            {
                return null;
            }

            var token = _jwtTokenService.GenerateToken(user);

            var tokenEntity = new TokenEntity
            {
                UserId = user.UUID,
                Token = token,
                ExpiredToken = DateTime.Now.AddMinutes(30)
            };

            _context.Mst_token.Add(tokenEntity);
            _context.SaveChanges();

            return tokenEntity;
        }

        public TokenEntity AuthLogout(string token)
        {
            return null;
        }
    }
}
