using System.Diagnostics.Eventing.Reader;
using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models;

namespace TechnoAcademyApi.Services.Impl
{
    public class ProgramCategoryService : IProgramCategoryService
    {
        private readonly ApplicationDbContext _context;
        public ProgramCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ResBase<ProgramCategory> Create(ProgramCategory programCategory)
        {
            try
            {
                _context.ProgramCategories.Add(programCategory);
                _context.SaveChanges();
                return new ResBase<ProgramCategory>()
                {
                    Data = programCategory
                };
            }catch (Exception ex)

            {
                return new ResBase<ProgramCategory>()
                {
                    Success = false,
                    Message = ex.Message,
                    Code = 400,
                    Data = null
                };
            }
        }
        public ResBase<ProgramCategory> Delete(string uuid)
        {
            var data = _context.ProgramCategories.FirstOrDefault(
                x => x.UUID == uuid);
            if (data != null)
            {
                _context.ProgramCategories.Remove(data);
                _context.SaveChanges();
                return new ResBase<ProgramCategory>() { Data = data };
            }
            else
            {
                return new ResBase<ProgramCategory>()
                {
                    Success = false,
                    Message = "Not Found",
                    Code = 404,
                    Data = null
                };
            }
        }

        public ResBase<List<ProgramCategory>> GetAll()
        {
            var data = _context.ProgramCategories.ToList();
            return new ResBase<List<ProgramCategory>>() { Data = data };
        }

        public ResBase<ProgramCategory> GetByUUID(string uuid)
        {
            var data = _context.ProgramCategories.FirstOrDefault(x => x.UUID == uuid);
            if (data != null)
            {
                return new ResBase<ProgramCategory>
                {
                    Data = data
                };
            }
            else
            {
                return new ResBase<ProgramCategory>
                {
                    Success = false,
                    Message = "Failed",
                    Code = 404,
                    Data = null
                };
            }
        }

        public ResBase<ProgramCategory> Update(string uuid, ProgramCategory programCategory)
        {
            var data = _context.ProgramCategories.FirstOrDefault(x => x.UUID == uuid);
            if (data != null)
            {
                data.Name = programCategory.Name;
                data.Flag = programCategory.Flag;
                data.DateStart = programCategory.DateStart;
                data.DateEnd = programCategory.DateEnd;
                _context.SaveChanges();
                return new ResBase<ProgramCategory> { Data = data };
            }
        else{
                return new ResBase<ProgramCategory>
                {
                    Success = false,
                    Code = 400,
                    Message = "Cant Update",
                    Data = null,
                };
            }
        }
    }
}
