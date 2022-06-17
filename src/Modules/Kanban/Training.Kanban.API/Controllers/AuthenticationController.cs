using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.Kanban.API.Interfaces;
using Training.Kanban.API.Models.Inputs;
using Training.Kanban.API.Models.Views;
using Training.Kanban.Domain.Interfaces;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.API.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IAuthenticationRepository authenticationRepository, ITokenService tokenService)
        {
            _authenticationRepository = authenticationRepository;
            _tokenService = tokenService;
        }

        [HttpPost("auth")]
        public async Task<ActionResult<JwtViewModel>> AuthenticateAsync([FromBody] LoginInputModel loginData)
        {
            var user = await _authenticationRepository.GetByLogin(loginData.Username, loginData.Password);

            if (user == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            var token = _tokenService.GenerateToken(user);

            return Json(new JwtViewModel
            {
                User = new()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                },
                Token = token
            });
        }

        [HttpGet("auth/{userId}")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> GetUserInformationAsync(int userId)
        {
            var user = await _authenticationRepository.GetById(userId);

            if (user == null)
                return Unauthorized(new { message = "Usuário não encontrado" });

            return Json(user);
        }

        [HttpPost("register")]
        public async Task<ActionResult<bool>> RegisterUser(User user)
        {
            var registered = await _authenticationRepository.Register(user);

            if (!registered)
                return BadRequest(new { message = "Não foi possível cadastrar o usuário" });

            return Ok();
        }


        [HttpGet("verify/email")]
        public async Task<IActionResult> VerifyEmailExists([FromQuery] string email)
        {
            var inUse = await _authenticationRepository.VerifyEmailExistsAsync(email);

            if (inUse)
                return BadRequest(new { message = "Email address already in use" });

            return Ok();
        }


        [HttpGet("verify/username")]
        public async Task<IActionResult> VerifyUsernameExists([FromQuery] string username)
        {
            var inUse = await _authenticationRepository.VerifyUsernameExistsAsync(username);

            if (inUse)
                return BadRequest(new { message = "Username already in use" });

            return Ok();
        }
    }
}
