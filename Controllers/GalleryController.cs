using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Entity;
using TechnoAcademyApi.Services;

namespace TechnoAcademyApi.Controllers
{
    [Route("api/v1/gallery")]
    [ApiController]
    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;
        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        [HttpPost]
        public IActionResult Create(GalleryEntity entity)
        {
            var res = _galleryService.Create(entity);
            return res == null ? BadRequest(res) : Ok(res);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var res = _galleryService.GetAll();
            return res == null ? BadRequest(res) : Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id) {
            var res = _galleryService.GetById(id);
            return res == null ? NotFound(res) : Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, GalleryEntity entity)
        {
            var res = _galleryService.Update(id, entity);
            return res == null ? NotFound(res) : Ok(res);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var res = _galleryService.Delete(id);
            return res == null ? NotFound(res) : Ok(res);
        }
    }
}
