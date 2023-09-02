using Microsoft.EntityFrameworkCore;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models;

namespace TechnoAcademyApi.Services.Impl
{
    public class ProgramEntityService : IProgramEntityService
    {
        private readonly ApplicationDbContext _context;

        public ProgramEntityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResBase<ProgramEntity> Create(ProgramEntity programEntity)
        {
            try
            {
                _context.ProgramEntities.Add(programEntity);
                _context.SaveChanges();

                // Eager loading untuk mengambil programCategory
                programEntity = _context.ProgramEntities
                    .Include(p => p.ProgramCategory)
                    .FirstOrDefault(p => p.UUID == programEntity.UUID);
                return new ResBase<ProgramEntity>()
                {
                    Data = programEntity
                };
            }
            catch (Exception ex)
            {
                return new ResBase<ProgramEntity>()
                {
                    Success = false,
                    Code = 400,
                    Message = ex.Message,
                    Data = null
                };
            }
        }


        public ResBase<ProgramEntity> Delete(string uuid)
        {
            var data = _context.ProgramEntities.FirstOrDefault( x => x.UUID == uuid );
            if ( data != null )
            {
                _context.ProgramEntities.Remove( data );
                _context.SaveChanges();
                return new ResBase<ProgramEntity>()
                { Data = data };
            }
            else
            {
                return new ResBase<ProgramEntity>()
                {
                    Success = false,
                    Code = 404,
                    Message = "Not Found",
                    Data = null
                };
            }
        }

        public ResBase<List<ProgramEntity>> GetAll()
        {
            try
            {
                var data = _context.ProgramEntities
                    .Include(p => p.ProgramCategory)
                    .ToList();

                return new ResBase<List<ProgramEntity>>() { Data = data };
            }
            catch (Exception ex)
            {
                return new ResBase<List<ProgramEntity>>()
                {
                    Success = false,
                    Code = 400,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        public ResBase<ProgramEntity> GetByUUID(string uuid)
        {
            try
            {
                var data = _context.ProgramEntities
                    .Include(p => p.ProgramCategory)
                    .FirstOrDefault(x => x.UUID == uuid);

                if (data != null)
                {
                    return new ResBase<ProgramEntity>
                    {
                        Data = data
                    };
                }
                else
                {
                    return new ResBase<ProgramEntity>()
                    {
                        Success = false,
                        Message = "Not Found",
                        Code = 404,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResBase<ProgramEntity>()
                {
                    Success = false,
                    Code = 400,
                    Message = ex.Message,
                    Data = null
                };
            }
        }
            public ResBase<ProgramEntity> Update(string uuid, ProgramEntity programEntity)
        {
            var data = _context.ProgramEntities.FirstOrDefault(x => x.UUID == uuid);
            if ( data != null )
            {
                data.Name = programEntity.Name;
                data.StatusProgram = programEntity.StatusProgram;
                data.Desc = programEntity.Desc;
                data.Flag = programEntity.Flag;
                data.IdCategory = programEntity.IdCategory;
                _context.SaveChanges();
                return new ResBase<ProgramEntity> { Data = data };
            }
            else
            {
                return new ResBase<ProgramEntity>
                {
                    Success = false,
                    Code = 404,
                    Message = "Not Found",
                    Data = null
                };
            }
        }
    }
}
