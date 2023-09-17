using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services
{
    public interface ICommentService
    {
        Comment? Create(Comment comment);
        Comment? GetById(string uuid);
        List<Comment> GetAll();
        Comment? Update(string uuid, Comment comment);
        Comment? Delete(string uuid);
        Comment? DeleteByUUID(string uuid);
    }
}
