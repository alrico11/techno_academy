using Microsoft.AspNetCore.Mvc;
using TechnoAcademyApi.Models.Dto.Res;
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
        public async Task<ActionResult<Response>> Create(GalleryEntity entity)
        {
            var res = await Task.FromResult(_galleryService.Create(entity));
            return res == null ? BadRequest() : new Response("success", res);
        }

        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            var res = await Task.FromResult(_galleryService.GetAll());
            return res == null ? BadRequest() : new Response("success", res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> Get(string id) {
            var res = await Task.FromResult(_galleryService.GetById(id));
            return res == null ? NotFound() : new Response("success", res);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> Update(string id, GalleryEntity entity)
        {
            var res = await Task.FromResult(_galleryService.Update(id, entity));
            return res == null ? NotFound(res) : new Response("success", res);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> Delete(string id)
        {
            var res = await Task.FromResult(_galleryService.Delete(id));
            return res == null ? NotFound(res) : new Response("success", res);
        }
    }
}
