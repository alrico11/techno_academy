using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Utils;

namespace TechnoAcademyApi.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResBase<UserEntity> Create(UserEntity entity)
        {
            try
            {
                entity.Password = PasswordHelper.EncryptPassword(entity.Password);
                _context.UserEntities.Add(entity);
                _context.SaveChanges();
                return new ResBase<UserEntity>
                {
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new ResBase<UserEntity>
                {
                    Success = false,
                    Data = null,
                    Code = 400,
                    Message = ex.Message
                };
            }
        }

        public ResBase<UserEntity>? Delete(string uuid)
        {
            var data = _context.UserEntities.Find(uuid);
            
            if (data == null)
            {
                return null;
            };
            _context.UserEntities.Remove(data);
            _context.SaveChanges();
            return new ResBase<UserEntity> { Message = "User Deleted",Data = data };
        }

        public ResBase<List<UserEntity>> GetAll()
        {
            var data = _context.UserEntities.Select(x => new UserEntity
            {
                UUID = x.UUID,
                Telephone = x.Telephone,
                Name = x.Name,
                Email = x.Email,
                Role = x.Role
            })
                .ToList();
            return new ResBase<List<UserEntity>>
            {
                Data = data
            };
        }

        public ResBase<UserEntity>? GetById(string uuid)
        {
            var data = _context.UserEntities.Find(uuid);
            return data == null ? null : new ResBase<UserEntity>
            {
                Data = data
            };
        }

        public ResBase<UserEntity>? Update(string uuid, UserEntity entity)
        {
            var data = _context.UserEntities.Find(uuid);
            if (data == null)
            {
                return null;
            };
            data.Email = entity.Email;
            data.Password = entity.Password;
            data.Role = entity.Role;
            data.Name = entity.Name;
            _context.SaveChanges();
            return new ResBase<UserEntity>
            {
                Message = "User Updated"
            };
        }
    }
}
