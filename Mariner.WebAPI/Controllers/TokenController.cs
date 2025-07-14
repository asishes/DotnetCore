using Mariner.Application.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken(UserInfoRequest model)
        {
            if (CheckCredentials(model.UserName, model.Password))
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                    null, null, DateTime.UtcNow.AddHours(1), signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }

        }
        private bool CheckCredentials(string userName, string Password)
        {
            var _username = _configuration["ApiConfiguration:ClientId"];
            var _password = _configuration["ApiConfiguration:ClientPwd"];

            return (userName.Equals(_username, StringComparison.OrdinalIgnoreCase) && Password == _password);
        }
    }
}
