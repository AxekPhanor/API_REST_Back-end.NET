using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModels;
using P7CreateRestApi.Services;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userRepository)
        {
            _userService = userRepository;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> Home()
        {
            return Ok(await _userService.List());
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddUser([FromBody] UserInputModel inputModel)
        {
            var user = await _userService.Create(inputModel);
            if (user is not null)
            {
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("validate")]
        public async Task<IActionResult> Validate([FromBody] UserInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userService.Create(inputModel);
            if (user is not null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("update/{id}")]
        public IActionResult ShowUpdateForm(int id)
        {
            var user = _userService.Get(id);
            
            if (user == null)
                throw new ArgumentException("Invalid user Id:" + id);

            return Ok();
        }

        [HttpPost]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserInputModel inputModel)
        {
            // TODO: check required fields, if valid call service to update Trade and return Trade list
            var user = await _userService.Update(id, inputModel);
            if (user is not null)
            {
                return Ok(await _userService.List());
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.Delete(id);
            if (user is not null)
            {
                return Ok(await _userService.List());
            }
            return NotFound();
        }

        [HttpGet]
        [Route("/secure/article-details")]
        public async Task<ActionResult<List<User>>> GetAllUserArticles()
        {
            return Ok();
        }
    }
}