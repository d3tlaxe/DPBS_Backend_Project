using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomsController : ControllerBase
    {

        IClassRoomService _classRoomService;

        public ClassRoomsController(IClassRoomService classRoomService)
        {
            _classRoomService = classRoomService;
        }



        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _classRoomService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(ClassRoom classRoom)
        {
            var result = _classRoomService.Add(classRoom);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete(ClassRoom classRoom)
        {
            var result = _classRoomService.Delete(classRoom);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ClassRoom classRoom)
        {
            var result = _classRoomService.Update(classRoom);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbiggerthanparameter")]
        public IActionResult GetBiggerThanParameter(int capacity)
        {
            var result = _classRoomService.GetBiggerThanParameter(capacity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyname")]
        public IActionResult GetByName(string roomName)
        {
            var result = _classRoomService.GetByName(roomName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }





    }

}
