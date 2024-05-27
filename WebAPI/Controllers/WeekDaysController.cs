using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekDaysController : ControllerBase
    {
        IWeekDayService _weekDayService;

        public WeekDaysController(IWeekDayService weekDayService)
        {
            _weekDayService = weekDayService;
        }


        [HttpGet("getallweekdays")]
        public IActionResult GetAll()
        {
            var result = _weekDayService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }




    }
}
