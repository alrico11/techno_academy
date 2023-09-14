using System.Diagnostics.Eventing.Reader;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class ProgramCategoryService : IProgramCategoryService
    {
        private readonly ApplicationDbContext _context;
        public ProgramCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ProgramCategory Create(ProgramCategory programCategory)
        {
            try
            {
                _context.Mst_program.Add(programCategory);
                _context.SaveChanges();
                return programCategory;
            }
            catch
            {
                return null;
            }
        }
        public ProgramCategory? Delete(string uuid)
        {
            var data = _context.Mst_program.FirstOrDefault(
                x => x.UUID == uuid);
            if (data == null)
            {
                return null;
            }
            _context.Mst_program.Remove(data);
            _context.SaveChanges();
            return data;
        }

        public List<ProgramCategory> GetAll()
        {
            var data = _context.Mst_program.Where(x => x.Flag_Active == true).ToList();
            return data;
        }

        public ProgramCategory? GetByUUID(string uuid)
        {
            var data = _context.Mst_program.FirstOrDefault(x => x.UUID == uuid);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public ProgramCategory? Update(string uuid, ProgramCategory programCategory)
        {
            var data = _context.Mst_program.FirstOrDefault(x => x.UUID == uuid);
            if (data == null)
            {
                return null;
            }
            data.Name = programCategory.Name;
            data.Flag_Active = programCategory.Flag_Active;
            data.DateStart = programCategory.DateStart;
            data.DateEnd = programCategory.DateEnd;
            data.Flag_Active = programCategory.Flag_Active;
            _context.SaveChanges();
            return data;
        }
    }
}
