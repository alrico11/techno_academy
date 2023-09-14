using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface ITestimonyService
    {
        List<TestimonyEntity> GetAll();
        TestimonyEntity? Get(string uuid);
        TestimonyEntity? Create(TestimonyEntity entity);
        TestimonyEntity? Update(string uuid,TestimonyEntity entity);
        TestimonyEntity? Delete(string uuid);
    }
}
