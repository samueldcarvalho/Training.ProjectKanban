using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Training.Kanban.Authentication.API.Models;
using Training.Kanban.Authentication.API.Models.Entity;
using Training.Kanban.Authentication.API.Models.Input;

namespace Training.Kanban.Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly JWTSettings _jwtSettings;
        public AuthenticationController(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Authenticate([FromBody] LoginInputModel loginData)
        {
            var user = new User
            {
                Id = 1,
                Username = "samueldcarvalho",
                Password = "123123123",
                Email = "samueldcarvalho99@gmail.com",
                Name = "Samuel de Carvalho"
            };

            if ((loginData.Username != user.Username) || (loginData.Password != user.Password))
                return NotFound(new { message = "Usuário ou senha inválidos."});

            var token = "";

            return new UserToken
            {
                Token = token,
                User = user
            };
        }

        private string GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
