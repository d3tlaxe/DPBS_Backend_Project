using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsAtClassRoomsController : ControllerBase
    {
        ILessonsAtClassRoomService _lessonAtClassRoomService;

        public LessonsAtClassRoomsController(ILessonsAtClassRoomService lessonAtClassRoomService)
        {
            _lessonAtClassRoomService = lessonAtClassRoomService;
        }



        [HttpGet("isclassroomavailable")]
        public IActionResult isClassRoomAvailable(int classRoomId, int lessonDay, int LessonStartTime)
        {
            var result = _lessonAtClassRoomService.isClassRoomAvailable(classRoomId, lessonDay, LessonStartTime);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(LessonAtClassRoom lessonAtClassRoom)
        {
            var result = _lessonAtClassRoomService.Add(lessonAtClassRoom);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
