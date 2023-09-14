using TechnoAcademyApi.Data;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;

namespace TechnoAcademyApi.Services.Impl
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Comment> GetAll()
        {
            var data = _context.Mst_comment_section.Where(x => x.Flag_Active == true)
                        .ToList();
            return data;
        }
        public Comment? GetById(string uuid)
        {
            var data = _context.Mst_comment_section.FirstOrDefault(x => x.UUID == uuid);
            return data == null ? null : data;
        }
        public Comment? Create(Comment comment)
        {
            try
            {
                _context.Mst_comment_section.Add(comment);
                _context.SaveChanges();
                return comment;
            }
            catch
            {
                return null;
            }
        }
        public Comment? Update(string uuid, Comment comment)
        {
            var existingComment = _context.Mst_comment_section.FirstOrDefault(x => x.UUID == uuid);
            if (existingComment == null)
            {
                return null;
            }
            existingComment.Content = comment.Content;
            existingComment.Flag_Active = comment.Flag_Active;

            _context.SaveChanges();
            return comment;
        }

        public Comment? Delete(string uuid)
        {
            var comment = _context.Mst_comment_section.FirstOrDefault(
                x => x.UUID == uuid);
            if (comment == null)
            {
                return null;
            }
            _context.Mst_comment_section.Remove(comment);
            _context.SaveChanges();
            return comment;
        }
    }
}
