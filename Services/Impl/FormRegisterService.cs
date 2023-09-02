using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models;

namespace TechnoAcademyApi.Services.Impl
{
    public class FormRegisterService : IFormRegisterService
    {
        private readonly ApplicationDbContext _context;

        public FormRegisterService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ResBase<List<FormRegister>> GetAllFormRegisters()
        {
            var formRegisters = _context.FormRegisters.ToList();
            return new ResBase<List<FormRegister>>
            {
                Data = formRegisters
            };
        }
        public ResBase<FormRegister> GetFormRegisterByUUID(string uuid)
        {
            var formRegister = _context.FormRegisters.FirstOrDefault(f => f.UUID == uuid);
            if (formRegister != null)
            {
                return new ResBase<FormRegister>
                {
                    Data = formRegister,
                };
            }
            else
            {
                return new ResBase<FormRegister>
                {
                    Success = false,
                    Message = "Not found",
                    Code = 404,
                    Data = null,
                };
            }
        }
        public ResBase<FormRegister> GetByEmail(string email)
        {
            var data = _context.FormRegisters.FirstOrDefault(x => x.Email == email);
            if (data != null)
            {
                return new ResBase<FormRegister> { Data = data };
            }
            else
            {
                return new ResBase<FormRegister>
                {
                    Success = false,
                    Message = "Not found",
                    Code = 404,
                    Data = null
                };
            }
        }
        public ResBase<FormRegister> CreateFormRegister(FormRegister formRegister)
        {
            bool emailExists = _context.FormRegisters.Any(fr => fr.Email == formRegister.Email);
            if (emailExists)
            {
                return new ResBase<FormRegister>
                {
                    Success = false,
                    Message = "Email already registered",
                    Code = 409,
                    Data = null,
                };
            }
            try
            {
                _context.FormRegisters.Add(formRegister);
                _context.SaveChanges();

                return new ResBase<FormRegister>
                {
                    Code = 201,
                    Data = formRegister
                };
            }
            catch (Exception ex)
            {
                return new ResBase<FormRegister>
                {
                    Success = false,
                    Message = ex.Message,
                    Code = 500,
                    Data = null,
                };
            }
        }
        public ResBase<FormRegister> UpdateFormRegister(string uuid, FormRegister formRegister)
        {
            var existingFormRegister = _context.FormRegisters.FirstOrDefault(f => f.UUID == uuid);
            if (existingFormRegister != null)
            {
                existingFormRegister.Name = formRegister.Name;
                existingFormRegister.Semester = formRegister.Semester;
                existingFormRegister.StudentStatus = formRegister.StudentStatus;
                existingFormRegister.IPK = formRegister.IPK;
                existingFormRegister.CV = formRegister.CV;
                existingFormRegister.University = formRegister.University;
                existingFormRegister.StudyProgram = formRegister.StudyProgram;
                _context.SaveChanges();
                return new ResBase<FormRegister>
                {
                    Data = existingFormRegister
                };
            }
            else
            {
                return new ResBase<FormRegister>
                {
                    Success = false,
                    Message = "Not Found",
                    Code = 404,
                    Data = null,
                };
            }
        }
        public ResBase<FormRegister> DeleteFormRegister(string uuid)
        {
            var formRegister = _context.FormRegisters.FirstOrDefault(f => f.UUID == uuid);
            if (formRegister != null)
            {
                _context.FormRegisters.Remove(formRegister);
                _context.SaveChanges();

                return new ResBase<FormRegister>
                {
                    Data = formRegister
                };
            }
            else
            {
                return new ResBase<FormRegister>
                {
                    Success = false,
                    Message = "Not found",
                    Code = 404,
                    Data = null,
                };
            }
        }
    }
}
