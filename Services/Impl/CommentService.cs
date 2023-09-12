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
        public ResBase<List<Comment>> GetAll()
        {
            var comments = _context.Comments.ToList();
            return new ResBase<List<Comment>>
            {
                Data = comments
            };
        }
        public ResBase<Comment> GetById(string uuid)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.UUID == uuid);
            if (comment != null)
            {
                return new ResBase<Comment>
                {
                    Data = comment
                };
            }
            else
            {
                return new ResBase<Comment>
                {
                    Success = false,
                    Code = 500,
                    Message = "Not Found",
                    Data = null,
                };
            }
        }
        public ResBase<Comment> Create(Comment comment)
        {
            try
            {

                _context.Comments.Add(comment);
                _context.SaveChanges();

                return new ResBase<Comment>
                {
                    Data = comment
                };
            }
            catch (Exception ex)
            {
                return new ResBase<Comment>()
                {
                    Success = false,
                    Code = 500,
                    Message = $"Failed to create comment: {ex.Message}",
                    Data = null
                };
            }
        }
        public ResBase<Comment> Update(string uuid, Comment comment)
        {
            var existingComment = _context.Comments.FirstOrDefault(x => x.UUID == uuid);
            if (existingComment != null)
            {
                existingComment.Content = comment.Content;
                _context.SaveChanges();
                return new ResBase<Comment>
                {
                    Message = "Comment Updated",
                    Data = existingComment
                };
            }
            else
            {
                return new ResBase<Comment>
                {
                    Success = false,
                    Code = 500,
                    Message = "Cant Updated",
                    Data = null
                };

            }
        }

        public ResBase<Comment> Delete(string uuid)
        {
            var comment = _context.Comments.FirstOrDefault(
                x => x.UUID == uuid);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
                return new ResBase<Comment>
                {
                    Success = true,
                    Message = "Comment Deleted",
                    Data = comment
                };
            }
            else
            {
                return new ResBase<Comment>
                {
                    Success = false,
                    Message = "Comment Not Found",
                    Data = null
                };
            }
        }
    }
}
