using TechnoAcademyApi.Models;

namespace TechnoAcademyApi.Services
{
    public interface IFormRegisterService
    {
        ResBase<FormRegister> CreateFormRegister(FormRegister formRegister);
        ResBase<FormRegister> GetFormRegisterByUUID(string uuid);
        ResBase<FormRegister> GetByEmail(string email);
        ResBase<List<FormRegister>> GetAllFormRegisters();
        ResBase<FormRegister> UpdateFormRegister(string uuid, FormRegister formRegister);
        ResBase<FormRegister> DeleteFormRegister(string uuid);
    }
}
