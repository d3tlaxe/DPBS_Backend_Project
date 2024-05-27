using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
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


        [HttpGet("getstudentlessonsbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _studentLessonService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getstudentprogram")]
        public IActionResult GetProgramForStudent(int studentId)
        {
            var result = _studentLessonService.GetProgramForStudent(studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }



        [HttpPost("add")]           ///// Burası DTO ile güncellenecek
        public IActionResult Add(int studentId, int lessonId, int prelectorId)
        {
            var result = _studentLessonService.Add(studentId, lessonId, prelectorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(StudentLesson studentLesson)
        {
            var result = _studentLessonService.Delete(studentLesson);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(StudentLesson studentLesson)
        {
            var result = _studentLessonService.Update(studentLesson);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("getstudentcount")]
        public IActionResult GetStudentCount(int lessonId, int prelectorId)
        {
            var result = _studentLessonService.GetStudentCount(lessonId, prelectorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
