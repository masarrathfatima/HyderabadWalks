using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HyderabadWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentnames= new string[] { "john", "mark" };
            return Ok(studentnames);
        }
    }
}
