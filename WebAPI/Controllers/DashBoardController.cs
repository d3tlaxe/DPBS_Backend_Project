using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        IDashBoardService _dashBoardService;

        public DashBoardController(IDashBoardService dashBoardService)
        {
            _dashBoardService = dashBoardService;
        }





        [HttpGet("getdashboard")]
        public IActionResult GetDashBoard()
        {
            var result = _dashBoardService.GetDashBoard();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


    }
}
