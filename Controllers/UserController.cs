using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Crmf;
using TechnoAcademyApi.Models.Dto.Req;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
       
        public async Task<ActionResult<Response>> Create(UserCmsReq entity)
        {
            var res = await Task.FromResult(_userService.Create(entity));
            return res == null ? BadRequest(res) : new Response("success");
        }

        [HttpGet("{uuid}")]
        public async Task<ActionResult<Response>> GetById(string uuid) {
        var res = await Task.FromResult(_userService.GetById(uuid));
            return res == null ? NotFound(res) : new Response("success",res);
        }
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            var res = await Task.FromResult(_userService.GetAll());
            return res == null? BadRequest(res) : new Response("success",res);
        }
        [HttpPut("{uuid}")]
        public async Task<ActionResult<Response>> Update(string uuid,UserEntity entity) {
        
            var res = await Task.FromResult(_userService.Update(uuid,entity));
            return res == null ? NotFound(res) : new Response("success");
        }
        [HttpDelete("{uuid}")]
        public async Task<ActionResult<Response>> Delete(string uuid)
        {
            var res = await Task.FromResult(_userService.Delete(uuid));
            return res == null ? NotFound() : new Response("success");
        }
        [HttpPut("delete/{uuid}")]
        public async Task<ActionResult<Response>> DeleteById(string uuid)
        {
            var res = await Task.FromResult(_userService.DeleteById(uuid));
            return res == null ? NotFound() : new Response("success");
        }
    }
}
