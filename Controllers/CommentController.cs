using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost]
        public async Task<ActionResult<Response>> Create(Comment comment)
        {
            var res = await Task.FromResult(_commentService.Create(comment));
            return res == null ? BadRequest() : new Response("success");
        }
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            var res = await Task.FromResult(_commentService.GetAll());
            return res == null ? BadRequest() : new Response("success", res);
        }
        [HttpGet("{uuid}")]
        public async Task<ActionResult<Response>> GetById(string uuid) {
            var res = await Task.FromResult(_commentService.GetById(uuid));
            return res == null ? NotFound() : new Response("success", res);
        }
        [HttpPut("{uuid}")]
        public async Task<ActionResult<Response>> Update(string uuid, Comment comment)
        {
            var res = await Task.FromResult(_commentService.Update(uuid, comment));
            return res == null ? NotFound() : new Response("success");

        }
        [HttpDelete("{uuid}")]
        public async Task<ActionResult<Response>> Delete(string uuid)
        {
            var res = await Task.FromResult(_commentService.Delete(uuid));
            return res == null ? NotFound() : new Response("success");
        }
        [HttpPut("delete/{uuid}")]
        public async Task<ActionResult<Response>> DeleteByUUID(string uuid)
        {
            var res = await Task.FromResult(_commentService.DeleteByUUID(uuid));
            return res == null ? NotFound() : new Response("success");
        }
    }
}
