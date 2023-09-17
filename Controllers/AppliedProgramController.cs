using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Models.Dto.Req;
using TechnoAcademyApi.Services;
using TechnoAcademyApi.Models.Dto.Res;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/appliedprogram")]
    [ApiController]
    public class AppliedProgramController : ControllerBase
    {
        private readonly IAppliedProgramService _appliedProgramService;

        public AppliedProgramController(IAppliedProgramService appliedProgramService)
        {
            _appliedProgramService = appliedProgramService;
        }
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            var result = await Task.FromResult(_appliedProgramService.GetAll());
            return result == null ? NotFound() : new Response("success",result);
        }

        [HttpGet("{uuid}")]
        public async Task<ActionResult<Response>> GetByUUID(string uuid) {
            var result = await Task.FromResult(_appliedProgramService.GetByUUID(uuid));
            return result == null ? NotFound() : new Response("success", result);
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Create(AppliedDto appliedProgramDto)
        {
            var result = await Task.FromResult(_appliedProgramService.Create(appliedProgramDto));
            return new Response("success");
        }
        [HttpPut("{uuid}")]
        public async Task<ActionResult<Response>> Update(string uuid, AppliedProgram appliedProgram)
        {
            var result = await Task.FromResult(_appliedProgramService.Update(uuid, appliedProgram));
            return result == null ? NotFound() : new Response("success");
        }
        [HttpDelete("{uuid}")]
        public async Task<ActionResult<Response>> Delete(string uuid)
        {
            var result = await Task.FromResult(_appliedProgramService.Delete(uuid));
            return result == null ? NotFound() : new Response("success");
        }
        [HttpPut("delete/{uuid}")]
        public async Task<ActionResult<Response>> DeleteByUUID(string uuid)
        {
            var result = await Task.FromResult(_appliedProgramService.DeleteByUUID(uuid));
            return result == null ? NotFound() : new Response("success");
        }

        [HttpPut("update-status/{uuid}")]
        public async Task<ActionResult<Response>> UpdateStatus(string uuid, UpdateStatusReq updateStatusReq)
        {
            var result = await Task.FromResult(_appliedProgramService.UpdateStatus(uuid, updateStatusReq));
            return result == null ? NotFound() : new Response("success");
        }
        [HttpPut("reject-status/{uuid}")]
        public async Task<ActionResult<Response>> RejectStatus(string uuid)
        {
            var result = await Task.FromResult(_appliedProgramService.RejectStatus(uuid));
            return result == null ? NotFound() : new Response("success");
        }
    }
}
