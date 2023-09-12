using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface ITestimonyService
    {
        ResBase<TestimonyEntity>? Get(string uuid);
        ResBase<List<TestimonyEntity>> GetAll();
        ResBase<TestimonyEntity> Create(TestimonyEntity entity);
        ResBase<TestimonyEntity>? Update(string uuid,TestimonyEntity entity);
        ResBase<TestimonyEntity>? Delete(string uuid);
    }
}
