using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonStartTimesController : ControllerBase
    {
        ILessonStartTimeService _lessonStartTimeService;

        public LessonStartTimesController(ILessonStartTimeService lessonStartTimeService)
        {
            _lessonStartTimeService = lessonStartTimeService;
        }


        [HttpGet("getalldailylessonhour")]
        public IActionResult GetAll()
        {
            var result = _lessonStartTimeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
