using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {

        ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet("getalllessons")]
        public IActionResult GetAll()
        {
            var result = _lessonService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(LessonForAddDto lessonForAddDto)
        {
            var result = _lessonService.Add(lessonForAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(Lesson lesson)
        {
            var result = _lessonService.Delete(lesson);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Lesson lesson)
        {
            var result = _lessonService.Update(lesson);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbylessonid")]
        public IActionResult GetById(int lessonId)
        {
            var result = _lessonService.GetById(lessonId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getbylessonname")]
        public IActionResult GetByName(string lessonName)
        {
            var result = _lessonService.GetByName(lessonName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getbyperiod")]
        public IActionResult GetByPeriod(int period)
        {
            var result = _lessonService.GetByPeriod(period);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyimperative")]
        public IActionResult GetByImperative(bool isImperative)
        {
            var result = _lessonService.GetByImperative(isImperative);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("gethighclasslessons")]
        public IActionResult GetHighClassLessons(int myPeriod)
        {
            var result = _lessonService.GetHighClassLessons(myPeriod);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }



    }
}
