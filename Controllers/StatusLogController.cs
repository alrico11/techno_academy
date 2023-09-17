using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/statuslog")]
    [ApiController]
    public class StatusLogController : Controller
    {
        private readonly IStatusLogService _statusLogService;
        public StatusLogController(IStatusLogService statusLogService)
        {
            _statusLogService = statusLogService;
        }
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            var res = await Task.FromResult(_statusLogService.GetAll());
            return res == null ? BadRequest() : new Response("success", res);
        }
        [HttpGet("{uuid}")]
        public async Task<ActionResult<Response>> GetByUUID(string uuid)
        {
            var res = await Task.FromResult(_statusLogService.GetByUUID(uuid));
            return res == null ? NotFound() : new Response("success", res);

        }
        [HttpPut("{uuid}")]
        public async Task<ActionResult<Response>> DeleteById(string uuid)
        {
            var res = await Task.FromResult(_statusLogService.DeleteById(uuid));
            return res == null ? NotFound() : new Response("success");
        }

        [HttpGet("search-email/{email}")]
        public async Task<ActionResult<Response>> GetStatusUserByEmail(string email)
        {
            var res = await Task.FromResult(_statusLogService.GetStatusUserByEmail(email));
            return res == null ? NotFound() : new Response("success", res);
        }
    }
}
