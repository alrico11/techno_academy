using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create(BannerEntity entity)
        {
            var res = _bannerService.Create(entity);
            return res == null ? BadRequest() : Ok(res);
        }
        [HttpGet]
        public IActionResult GetAll() {
            var res = _bannerService.GetAll();
            return res == null ? BadRequest() : Ok(res);
        }
        [HttpGet("{uuid}")]
        public IActionResult GetById(string uuid) { 
        
            var res = _bannerService.GetById(uuid);
            return res == null? NotFound() : Ok(res);
        }

        [HttpPut("{uuid}")]
        public IActionResult Update(string uuid, BannerEntity entity)
        {
            var res = _bannerService.Update(uuid, entity);
            return res == null ? NotFound(res) : Ok(res);
        }
        [HttpDelete("{uuid}")]
        public IActionResult Delete(string uuid)
        {
            var res = _bannerService.Delete(uuid);
            return res == null ? NotFound(res) : Ok(res);
        }
    }
}
