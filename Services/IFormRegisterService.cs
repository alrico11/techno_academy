using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface IFormRegisterService
    {
        FormRegister? CreateFormRegister(FormRegister formRegister);
        FormRegister? GetFormRegisterByUUID(string uuid);
        FormRegister? GetByEmail(string email);
        List<FormRegister> GetAllFormRegisters();
        FormRegister? UpdateFormRegister(string uuid, FormRegister formRegister);
        FormRegister? DeleteFormRegister(string uuid);
        FormRegister? DeleteByUUID(string uuid);
    }
}
