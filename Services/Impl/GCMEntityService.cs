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
        public GCMEntity? Create(GCMEntity entity)
        {
            try
            {
                _context.Mst_GCM_Academy.Add(entity);
                _context.SaveChanges();
                return entity;
            }catch
            {
                return null;
            }
        }

        public GCMEntity? Delete(string uuid)
        {
            var data = _context.Mst_GCM_Academy.FirstOrDefault(x => x.UUID == uuid);
            return data == null ? null : data;
        }

        public List<GCMEntity> GetAll()
        {
           var data = _context.Mst_GCM_Academy.Where(x => x.Flag_Active == true).ToList();
            return data;
        }

        public GCMEntity? GetByUUID(string uuid)
        {
            var data = _context.Mst_GCM_Academy.FirstOrDefault(x => x.UUID == uuid);
            return data == null ? null : data;
        }
        public GCMEntity? Update(string uuid, GCMEntity entity)
        {
            var data = _context.Mst_GCM_Academy.FirstOrDefault(x => x.UUID == uuid);
            if(data == null)
            {
                return null;
            }
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
            data.Status = entity.Status;
            data.Flag_Active = entity.Flag_Active;
            _context.SaveChanges();
            return entity;
        }
        public List<GCMEntity>? GetByCondition(string condition)
        {
            var data = _context.Mst_GCM_Academy.Where(entity => entity.Condition == condition).ToList();
            return data == null ? null : data;
        }
        public ResGcmCondition? GetCondition()
        {
            var data = _context.Mst_GCM_Academy.ToList();
            var conditions = data.Select(i => i.Condition).Distinct().ToArray();
            var newDataCondition = new ResGcmCondition
            {
                Condition = conditions,
            };
            return data == null ? null : newDataCondition;
        }
        public GCMEntity? DeleteByUUID(string uuid)
        {
            var data = _context.Mst_GCM_Academy.FirstOrDefault(x => x.UUID == uuid);
            if (data == null)
            {
                return null;
            }
            data.Flag_Active = false;
            _context.SaveChanges();
            return data;
        }
    }
}
