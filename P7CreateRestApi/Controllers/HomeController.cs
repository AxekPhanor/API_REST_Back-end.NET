using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize()]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Authorize(policy: "User")]
        public IActionResult Get()
        {
            return Ok(Request.Headers["Authorization"]);
        }

        [HttpGet]
        [Route("Admin")]
        [Authorize(policy: "Admin")]
        public IActionResult Admin()
        {
            return Ok();
        }
    }
}