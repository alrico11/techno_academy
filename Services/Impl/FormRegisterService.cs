using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Req;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class FormRegisterService : IFormRegisterService
    {
        private readonly ApplicationDbContext _context;

        public FormRegisterService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<FormRegister> GetAllFormRegisters()
        {
            List<FormRegister> data = _context.Mst_user.Where(x => x.Flag_Active).ToList();
            return data;
        }
        public FormRegister? GetFormRegisterByUUID(string uuid)
        {
            var data = _context.Mst_user.FirstOrDefault(f => f.UUID == uuid);
            return data == null ? null : data;
        }
        public FormRegister? GetByEmail(string email)
        {
            var data = _context.Mst_user.FirstOrDefault(x => x.Email == email);
            return data == null ? null : data;
        }
        public FormRegister? CreateFormRegister(FormRegister formRegister)
        {
            bool emailExists = _context.Mst_user.Any(fr => fr.Email == formRegister.Email);
            if (emailExists)
            {
                return null;
            }
            try
            {
                _context.Mst_user.Add(formRegister);
                _context.SaveChanges();
                return formRegister;
            }
            catch
            {
                return null;
            }
        }
        public FormRegister? UpdateFormRegister(string uuid, FormRegister formRegister)
        {
            var data = _context.Mst_user.FirstOrDefault(f => f.UUID == uuid);
            if (data == null)
            {
                return null;
            }
            data.Name = formRegister.Name;
            data.Semester = formRegister.Semester;
            data.StudentStatus = formRegister.StudentStatus;
            data.IPK = formRegister.IPK;
            data.CV = formRegister.CV;
            data.University = formRegister.University;
            data.StudyProgram = formRegister.StudyProgram;
            data.Flag_Active = formRegister.Flag_Active;
            _context.SaveChanges();
            return formRegister;
        }
        public FormRegister? DeleteFormRegister(string uuid)
        {
            var formRegister = _context.Mst_user.FirstOrDefault(f => f.UUID == uuid);
            if (formRegister == null)
            {
                return null;
            };
            _context.Mst_user.Remove(formRegister);
            _context.SaveChanges();
            return formRegister;
        }
    }
}
