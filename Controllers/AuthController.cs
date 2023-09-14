using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Dto.Req;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/auth/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Response>> Login([FromBody] Auth auth)
        {
            var res = await Task.FromResult(_authService.AuthLogin(auth));
            return res == null ? BadRequest() : new Response("success",res);
        }

        [HttpPost("logout")]
        public async Task<ActionResult<Response>> Logout([FromBody] string token)
        {
            var res = _authService.AuthLogout(token);
            return res == null ? BadRequest() : new Response("success", res);
        }
    }
}
