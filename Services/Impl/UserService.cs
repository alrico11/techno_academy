using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Req;
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

        public UserCmsReq? Create(UserCmsReq entity)
        {
            try
            {
                entity.Password = PasswordHelper.EncryptPassword(entity.Password);
                UserEntity userEntity = new UserEntity
                {
                    Name = entity.Name,
                    Email = entity.Email,
                    Password = entity.Password,
                    Telephone = entity.Telephone,
                    Role = entity.Role
                };
                _context.Mst_user_cms.Add(userEntity);
                _context.SaveChanges();
                return entity;
            }
            catch
            {
                return null;
            }
        }

        public UserEntity? Delete(string uuid)
        {
            var data = _context.Mst_user_cms.Find(uuid);
            
            if (data == null)
            {
                return null;
            };
            _context.Mst_user_cms.Remove(data);
            _context.SaveChanges();
            return data;
        }

        public List<UserCmsRes> GetAll()
        {
            var data = _context.Mst_user_cms
                        .Where(x => x.Flag_Active == true)
                        .Select(x => new UserCmsRes
                        {
                            UUID = x.UUID,
                            Telephone = x.Telephone,
                            Name = x.Name,
                            Email = x.Email,
                            Role = x.RoleEntity.RoleName
                        })
                        .ToList();
            return data;
        }
        public UserEntity? GetById(string uuid)
        {
            var query = from user in _context.Mst_user_cms
                        join role in _context.Mst_role on user.Role equals role.UUID
                        where user.UUID == uuid
                        select new UserEntity
                        {
                            UUID = user.UUID,
                            Telephone = user.Telephone,
                            Name = user.Name,
                            Email = user.Email,
                            Role = role.RoleName
                        };

            var userEntity = query.FirstOrDefault();

            return userEntity == null  ? null : userEntity;
        }
        public UserEntity? Update(string uuid, UserEntity entity)
        {
            var data = _context.Mst_user_cms.Find(uuid);
            if (data == null)
            {
                return null;
            };
            data.Email = entity.Email;
            data.Password = entity.Password;
            data.Role = entity.Role;
            data.Name = entity.Name;
            data.Flag_Active = entity.Flag_Active;
            _context.SaveChanges();
            return data;
        }
    }
}
