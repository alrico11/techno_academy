using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/testimony")]
    [ApiController]
    public class TestimonyController : ControllerBase
    {
        private readonly ITestimonyService _testimonyService;
        public TestimonyController(ITestimonyService testimonyService)
        {
            _testimonyService = testimonyService;
        }
        [HttpPost]
        public async Task<ActionResult<Response>> Create(TestimonyEntity entity)
        {
            var res = await Task.FromResult(_testimonyService.Create(entity));
            return res == null ? BadRequest() : new Response("success");
        }

        [HttpGet]
        public async Task<ActionResult<Response>>GetAll()
        {
            var res = await Task.FromResult(_testimonyService.GetAll());
            return res == null ? NotFound() : new Response("success", res);
        }
        [HttpGet("{uuid}")]
        public async Task<ActionResult<Response>> GetByID(string uuid)
        {
            var res = await Task.FromResult(_testimonyService.Get(uuid));
            return res == null ? NotFound() : new Response("success", res);
        }
        [HttpPut("{uuid}")]
        public async Task<ActionResult<Response>>  Update(string uuid, TestimonyEntity entity)
        {
            var res = await Task.FromResult(_testimonyService.Update(uuid, entity));
            return res == null ? NotFound(res) : new Response("success");
        }

        [HttpDelete("{uuid}")]
        public async Task<ActionResult<Response>> Delete(string uuid)
        {
            var res = await Task.FromResult(_testimonyService.Delete(uuid));
            return res == null ? NotFound(res) : new Response("success");
        }
        [HttpPut("delete/{uuid}")]
        public async Task<ActionResult<Response>> DeleteById(string uuid)
        {
            var res = await Task.FromResult(_testimonyService.DeleteById(uuid));
            return res == null ? NotFound(res) : new Response("success");
        }
    }
}
