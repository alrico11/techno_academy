using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class GCMEntityService : IGCMEntityService
    {
        private readonly ApplicationDbContext _context;
        public GCMEntityService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ResBase<GCMEntity> Create(GCMEntity entity)
        {
            try
            {
                _context.GCMEntities.Add(entity);
                _context.SaveChanges();
                return new ResBase<GCMEntity>()
                {
                    Data = entity
                };
            }catch(Exception ex)
            {
                return new ResBase<GCMEntity>()
                {
                    Success = false,
                    Message = ex.Message,
                    Code = 400,
                    Data = null
                };
            }
        }

        public ResBase<GCMEntity> Delete(string uuid)
        {
            var data = _context.GCMEntities.FirstOrDefault(x => x.UUID == uuid);
            if (data != null)
            {
                return new ResBase<GCMEntity> { Message = "Deleted successfully",Data = data };
            }
            else
            {
                return new ResBase<GCMEntity>
                {
                    Message = "Not found",
                    Code = 404,
                    Data = null,
                    Success = false
                };
            }
        }

        public ResBase<List<GCMEntity>> GetAll()
        {
           var data = _context.GCMEntities.ToList();
            return new ResBase<List<GCMEntity>>
            {
                Data = data
            };
        }

        public ResBase<GCMEntity>? GetByUUID(string uuid)
        {
            var data = _context.GCMEntities.FirstOrDefault(x => x.UUID == uuid);
            if(data != null)
            {
                return new ResBase<GCMEntity>
                {
                    Data = data
                };
            }
            else
            {
                return null;
            }
        }

        public ResBase<GCMEntity>? Update(string uuid, GCMEntity entity)
        {
            var data = _context.GCMEntities.FirstOrDefault(x => x.UUID == uuid);
            if(data != null)
            {
                data.Condition = entity.Condition;
                data.CharValue1 = entity.CharValue1;
                data.CharValue2 = entity.CharValue2;
                data.CharValue3 = entity.CharValue3;
                data.CharValue4 = entity.CharValue4;
                data.CharValue5 = entity.CharValue5;
                data.CharDesc1 = entity.CharDesc1;
                data.CharDesc2 = entity.CharDesc2;
                data.CharDesc3 = entity.CharDesc3;
                data.CharDesc4 = entity.CharDesc4;
                data.CharDesc5 = entity.CharDesc5;
                data.Flag = entity.Flag;
                _context.SaveChanges();
                return new ResBase<GCMEntity>
                {
                    Data = data
                };
            }
            else
            {
                return null;
            }
        }
    }
}
