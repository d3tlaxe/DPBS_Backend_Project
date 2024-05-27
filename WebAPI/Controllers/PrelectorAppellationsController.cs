using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrelectorAppellationsController : ControllerBase
    {
        IPrelectorAppellationService _prelectorAppellationService;

        public PrelectorAppellationsController(IPrelectorAppellationService prelectorAppellationService)
        {
            _prelectorAppellationService = prelectorAppellationService;
        }

        [HttpGet("getallappellations")]
        public IActionResult GetAll()
        {
            var result = _prelectorAppellationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
