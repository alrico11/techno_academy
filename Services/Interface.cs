using TechnoAcademyApi.Models;

namespace TechnoAcademyApi.Services
{
    public interface IFormRegisterService
    {
        ResBase<FormRegister> CreateFormRegister(FormRegister formRegister);
        // Declare other methods for CRUD operations
    }
}
