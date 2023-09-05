using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Crmf;
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
        [Authorize]
        public IActionResult Create(UserEntity entity)
        {
            var res = _userService.Create(entity);
            return res == null ? BadRequest(res) : Ok(res);
        }

        [HttpGet("{uuid}")]
        public IActionResult GetById(string uuid) {
        var res = _userService.GetById(uuid);
            return res == null ? NotFound(res) : Ok(res);
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var res = _userService.GetAll();
            return res == null? BadRequest(res) : Ok(res);
        }
        [HttpPut("{uuid}")]
        public IActionResult Update(string uuid,UserEntity entity) {
        
            var res = _userService.Update(uuid,entity);
            return res == null ? NotFound(res) : Ok(res);
        }
        [HttpDelete("{uuid}")]
        public IActionResult DeleteById(string uuid)
        {
            var res = _userService.Delete(uuid);
            return res == null ? NotFound() : Ok(res);
        }
    }
}
