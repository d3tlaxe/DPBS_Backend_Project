using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentLessonsController : ControllerBase
    {
        IStudentLessonService _studentLessonService;

        public StudentLessonsController(IStudentLessonService studentLessonService)
        {
            _studentLessonService = studentLessonService;
        }


        [HttpGet("getuserlessonsbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _studentLessonService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
