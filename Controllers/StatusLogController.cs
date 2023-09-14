//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
//using TechnoAcademyApi.Models.Entity;
//using TechnoAcademyApi.Services;

//namespace TechnoAcademyApi.Controllers
//{
//    [Route("api/v1/statuslog")]
//    [ApiController]
//    public class StatusLogController : Controller
//    {
//        private readonly IStatusLogService _statusLogService;
//        public StatusLogController(IStatusLogService statusLogService)
//        {
//            _statusLogService = statusLogService;
//        }
//        [HttpGet]
//        public IActionResult GetAll() {

//            var res = _statusLogService.GetAll();
//            if (res.Success)
//            {
//                return Ok(res);
//            }
//            else
//            {
//                return BadRequest(res);
//            }
//        }

//        [HttpGet("{uuid}")]
//        public IActionResult GetByUUID(string uuid) {

//            var res = _statusLogService.GetByUUID(uuid);
//            if (res.Success)
//            {
//                return Ok(res);
//            }
//            else
//            {
//                return BadRequest(res);
//            }
//        }

//        [HttpPost]

//        public IActionResult Create(StatusLog statusLog)
//        {
//            var res = _statusLogService.Create(statusLog);
//            if (res.Success) {
//                return Ok(res);
//            }
//            else
//            {
//                return BadRequest(res);
//            }
//        }
//        [HttpPut("{uuid}")]
//        public IActionResult Update(string uuid, StatusLog statusLog)
//        {
//            var res = _statusLogService.Update(uuid, statusLog);
//            if (res.Success)
//            {
//                return Ok(res);
//            }
//            else
//            {
//                return BadRequest(res);
//            }
//        }
//        [HttpPut("reject/{uuid}")]
//        public IActionResult Reject(string uuid, StatusLog statusLog)
//        {
//            var res = _statusLogService.UpdatedReject(uuid, statusLog);
//            if (res.Success)
//            {
//                return Ok(res);
//            }
//            else
//            {
//                return BadRequest(res);
//            }
//        }
//        [HttpDelete("{uuid}")]
//        public IActionResult Delete(string uuid)
//        {
//            var res = _statusLogService.Delete(uuid);
//            if (res.Success)
//            {
//                return Ok(res);
//            }
//            else
//            {
//                return BadRequest(res);
//            }
//        }
//    }
//}
