using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Dto.Res;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/banner")]
    [ApiController]
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        [HttpPost]
        public async Task<ActionResult<Response>> Create(BannerEntity entity)
        {
            var res = await Task.FromResult(_bannerService.Create(entity));
            return res == null ? BadRequest() : new Response("success",res);
        }
        [HttpGet]
        public async Task<ActionResult<Response>> GetAll() {
            var res = await Task.FromResult(_bannerService.GetAll());
            return res == null ? BadRequest() : new Response("success", res);
        }
        [HttpGet("{uuid}")]
        public async Task<ActionResult<Response>> GetById(string uuid) { 
        
            var res = await Task.FromResult(_bannerService.GetById(uuid));
            return res == null ? NotFound() : new Response("success", res);
        }

        [HttpPut("{uuid}")]
        public async Task<ActionResult<Response>> Update(string uuid, BannerEntity entity)
        {
            var res = await Task.FromResult(_bannerService.Update(uuid, entity));
            return res == null ? NotFound() : new Response("success", res);
        }
        [HttpDelete("{uuid}")]
        public async Task<ActionResult<Response>> Delete(string uuid)
        {
            var res = await Task.FromResult(_bannerService.Delete(uuid));
            return res == null ? NotFound() : new Response("success", res);
        }
    }
}
