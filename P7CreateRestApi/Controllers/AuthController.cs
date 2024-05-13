using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using P7CreateRestApi.Models.InputModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {   
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly ILogger<AuthController> _logger;
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _config = config;
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginInputModel inputModel)
        {
            _logger.LogInformation("Authentification de l'utilisateur {UserName}", inputModel.UserName);
            try
            {
                var user = await _userManager.FindByNameAsync(inputModel.UserName);
                var result = await _userManager.CheckPasswordAsync(user, inputModel.Password);
                if (result)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role, user.Role)
                        }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        Audience = _config["Jwt:Audience"],
                        Issuer = _config["Jwt:Issuer"],
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(new { Token = tokenString });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Erreur lors de l'authentification de l'utilisateur {UserName}", inputModel.UserName);
                return StatusCode(500, "Une erreur interne s'est produite");
            }
            return Unauthorized();
        }
    }
}