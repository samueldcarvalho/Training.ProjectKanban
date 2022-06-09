using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.Authentication.API.Interfaces;
using Training.Authentication.API.Models;
using Training.Authentication.API.Models.Inputs;
using Training.Authentication.API.Models.Views;

namespace Training.Authentication.API.Controllers
{
    [Route("authentication")]
    public class AuthenticationController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<JwtViewModel>> AuthenticateAsync([FromBody] LoginInputModel loginData)
        {
            var user = _userRepository.Get(loginData.Username, loginData.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos"});

            var token = _tokenService.GenerateToken(user);

            return new JwtViewModel
            {
                Id = user.Id,
                Token = token
            };
        }
    }
}
