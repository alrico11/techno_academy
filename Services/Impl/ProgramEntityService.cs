using Microsoft.EntityFrameworkCore;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class ProgramEntityService : IProgramEntityService
    {
        private readonly ApplicationDbContext _context;

        public ProgramEntityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProgramEntity? Create(ProgramEntity programEntity)
        {
            try
            {
                _context.Mst_applied_program.Add(programEntity);
                _context.SaveChanges();
                programEntity = _context.Mst_applied_program
                                .Include(p => p.ProgramCategory)
                                .FirstOrDefault(p => p.UUID == programEntity.UUID);
                return programEntity;
            }
            catch
            {
                return null;
            }
        }

        public ProgramEntity Delete(string uuid)
        {
            var data = _context.Mst_applied_program.FirstOrDefault( x => x.UUID == uuid );
            if ( data == null )
            {
                return null;
            }
            _context.Mst_applied_program.Remove(data);
            _context.SaveChanges();
            return data;
        }

        public List<ProgramEntity> GetAll()
        {
            var data = _context.Mst_applied_program
                        .Where(x => x.Flag_Active == true)
                        .Include(p => p.ProgramCategory)
                        .ToList();
            return data;
        }

        public ProgramEntity? GetByUUID(string uuid)
        {
            var data = _context.Mst_applied_program
                .Include(p => p.ProgramCategory)
                .FirstOrDefault(x => x.UUID == uuid);

            if (data == null)
            {
                return null;
            }
            return data;
         }
        public ProgramEntity? Update(string uuid, ProgramEntity programEntity)
        {
            var data = _context .Mst_applied_program.FirstOrDefault(x => x.UUID == uuid);
            if ( data == null )
            {
                return null;
            }
            data.Name = programEntity.Name;
            data.StatusProgram = programEntity.StatusProgram;
            data.Desc = programEntity.Desc;
            data.Flag = programEntity.Flag;
            data.IdCategory = programEntity.IdCategory;
            data.Flag_Active = programEntity.Flag_Active;
            data.Pict = programEntity.Pict;
            _context.SaveChanges();
            return data;
        }
        public ProgramEntity? DeleteByUUID(string uuid)
        {
            var data = _context.Mst_applied_program.FirstOrDefault(x => x.UUID == uuid);
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
