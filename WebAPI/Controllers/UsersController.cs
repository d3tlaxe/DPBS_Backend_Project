using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("login")]
        public IActionResult Login(string email, string password)
        {
            var result = _userService.LoginCheck(email, password);

            if (result.Success)
            {
                return Ok(result);
            }
            else if(!result.Success)                // Buraya else bloğunu ben ekledim denemek için. Çalıştı. 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallusers")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getstudentwithdetails")]
        public IActionResult GetStudentDetails(int id) 
        {
            var result = _userService.GetStudentDetails(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getprelectorwithdetails")]
        public IActionResult GetPrelectorDetails(int id)
        {
            var result = _userService.GetPrelectorDetails(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
