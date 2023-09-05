﻿using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Dto.Req;
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

        public IActionResult Login(Auth auth)
        {
            var res = _authService.AuthLogin(auth);
            return res == null? BadRequest() : Ok(res);
        }
        [HttpPost("logout")]
        public IActionResult Logout(string token) { 
            var res = _authService.AuthLogout(token);
            return res == null? BadRequest(res) : Ok(res);
        }
    }
}
