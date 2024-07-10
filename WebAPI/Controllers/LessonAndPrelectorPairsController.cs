using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonAndPrelectorPairsController : ControllerBase
    {
        ILessonAndPrelectorPairService _lessonAndPrelectorService;

        public LessonAndPrelectorPairsController(ILessonAndPrelectorPairService lessonAndPrelectorService)
        {
            _lessonAndPrelectorService = lessonAndPrelectorService;
        }


        [HttpGet("getlessonsofprelectorbyid")]
        public IActionResult GetByPrelectorId(int prelectorId)
        {
            var result = _lessonAndPrelectorService.GetByPrelectorId(prelectorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getprelectorsoflessonbyid")]
        public IActionResult GetByLessonId(int lessonId)
        {
            var result = _lessonAndPrelectorService.GetByLessonId(lessonId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("addprelectortolesson")]
        public IActionResult Add(int lessonId, int prelectorId)
        {
            var result = _lessonAndPrelectorService.AddByParameter(lessonId, prelectorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getpairid")]
        public IActionResult GetPairId(int lessonId, int prelectorId)
        {
            var result = _lessonAndPrelectorService.GetPairId(lessonId, prelectorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
