using TechnoAcademyApi.Models;

namespace TechnoAcademyApi.Services
{
    public interface ICommentService
    {
        ResBase<Comment> Create(Comment comment);
        ResBase<List<Comment>> GetAll();
        ResBase<Comment> GetById(string uuid);
        ResBase<Comment> Update(string uuid, Comment comment);
        ResBase<Comment> Delete(string uuid);
    }
}
