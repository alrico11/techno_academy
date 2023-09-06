using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Req;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public AuthService(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public ResBase<TokenEntity> AuthLogin(Auth auth)
        {
            // Lakukan validasi login, misalnya dengan memeriksa kecocokan dengan data yang ada di basis data
            var user = _context.UserEntities.FirstOrDefault(u => u.Email == auth.Email);

            if (user == null || user.Password != auth.Password)
            {
                return new ResBase<TokenEntity>
                {
                    Success = false,
                    Code = 401,
                    Message = "Invalid username or password",
                    Data = null
                };
            }
            if (string.IsNullOrEmpty(auth.Password) || string.IsNullOrEmpty(auth.Email))
            {
                return new ResBase<TokenEntity>
                {
                    Success = false,
                    Code = 400,
                    Message = "Email & Password is required",
                    Data = null
                };
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:JwtAuth:SecretKey"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.Aes128CbcHmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("Date", DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
                        var token = new JwtSecurityToken(
                _configuration["AppSettings:JwtAuth:Issuer"],
                _configuration["AppSettings:JwtAuth:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);
            var dataToken = new JwtSecurityTokenHandler().WriteToken(token);

            var tokenEntity = new TokenEntity
            {
                Token = dataToken,
                UserId = user.UUID,
                ExpiredToken = DateTime.Now.AddMinutes(1)
            };
            _context.TokenEntities.Add(tokenEntity);
            _context.SaveChanges();

            return new ResBase<TokenEntity>
            {
                Success = true,
                Code = 200,
                Message = "Authentication successful",
                Data = tokenEntity
            };
        }

        public ResBase<TokenEntity> AuthLogout(string token)
        {
            // Implementasi proses logout di sini
            // Misalnya, Anda dapat memvalidasi token dan menghapus token dari daftar token yang valid
            // Kemudian, kembalikan respons yang sesuai

            return new ResBase<TokenEntity>
            {
                Success = true,
                Code = 200,
                Message = "Logout successful",
                Data = null
            };
        }
    }
}
