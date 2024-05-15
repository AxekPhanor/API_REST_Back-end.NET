using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Services;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userRepository, ILogger<UserController> logger)
        {
            _userService = userRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> Home()
        {
            _logger.LogInformation("Récupération de la liste des 'User'");
            try
            {
                return Ok(await _userService.List());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de la récupération des listes 'User'");
                return StatusCode(500, "Une erreur interne s'est produite");
            }
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddUser([FromBody] UserInputModel inputModel)
        {
            _logger.LogInformation("Ajout d'un nouvel utilisateur");
            try
            {
                var user = await _userService.Create(inputModel);
                if (user is not null)
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de l'ajout d'un nouvel utilisateur");
                return StatusCode(500, "Une erreur interne s'est produite");
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
            _logger.LogInformation("Mise à jour de l'utilisateur avec l'id : {id}", id);
            try
            {
                var user = await _userService.Update(id, inputModel);
                if (user is not null)
                {
                    return Ok(await _userService.List());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la mise à jour de l'utilisateur avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _logger.LogInformation("Suppression de l'utilisateur avec l'id : {id}", id);
            try
            {
                var user = await _userService.Delete(id);
                if (user is not null)
                {
                    return Ok(await _userService.List());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de la suppression de l'utilisateur avec l'id : {id}", id);
                return StatusCode(500, "Une erreur interne s'est produite");
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