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

        [HttpPost("addwithparameter")]
        public IActionResult AddWithParameter(int classroomId, int lessonId, int prelectorId, int lessonDayId, int lessonStartTimeId)
        {
            var result = _lessonAtClassRoomService.AddWithParameter(classroomId, lessonId, prelectorId, lessonDayId, lessonStartTimeId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getprelectorprogram")]
        public IActionResult GetProgramForPrelector(int prelectorId)
        {
            var result = _lessonAtClassRoomService.GetProgramForPrelector(prelectorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getplannedclassrom")]
        public IActionResult GetPlannedClassRooms()
        {
            var result = _lessonAtClassRoomService.GetPlannedClassrooms();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getplannedlesson")]
        public IActionResult GetPlannedLessons()
        {
            var result = _lessonAtClassRoomService.GetPlannedLesson();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getplannedprelector")]
        public IActionResult GetPlannedPrelectors()
        {
            var result = _lessonAtClassRoomService.GetPlannedPrelector();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }





    }
}
