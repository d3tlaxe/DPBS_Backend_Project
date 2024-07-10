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
        IPrelectorDetailService _prelectorDetailService;
        IStudentDetailService _studentDetailService;

        public UsersController(IUserService userService, IPrelectorDetailService prelectorDetailService, IStudentDetailService studentDetailService)
        {
            _userService = userService;
            _prelectorDetailService = prelectorDetailService;
            _studentDetailService = studentDetailService;
        }


        [HttpGet("login")]
        public IActionResult Login(string email, string password)
        {
            var result = _userService.LoginCheck(email, password);

            if (result.Success)
            {
                return Ok(result);
            }
            else if(!result.Success)               
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


        [HttpPost("addprelector")]
        public IActionResult AddPrelector(PrelectorForAddDto prelectorForAddDto)
        {
            var result = _prelectorDetailService.Add(prelectorForAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("addstudent")]
        public IActionResult AddStudent(StudentForAddDto studentForAddDto)
        {
            var result = _studentDetailService.Add(studentForAddDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
