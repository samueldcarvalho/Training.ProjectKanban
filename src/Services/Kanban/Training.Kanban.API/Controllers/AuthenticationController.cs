using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Training.Kanban.API.Interfaces;
using Training.Kanban.Application.Models.Inputs;
using Training.Kanban.Application.Models.Views;
using Training.Kanban.Domain.Interfaces;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.API.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : Controller
    {
        private readonly IUserRepository _authenticationRepository;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IUserRepository authenticationRepository, ITokenService tokenService)
        {
            _authenticationRepository = authenticationRepository;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Autentica a sessão, com dados de login e retorna JWT
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Obtém o usuário a partir do ID, que se encontra ao decodificar o JWT.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("auth/{userId}")]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> GetUserInformationAsync(int userId)
        {
            var user = await _authenticationRepository.GetById(userId);

            if (user == null)
                return Unauthorized(new { message = "Usuário não encontrado" });

            return Json(user);
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<bool>> RegisterUser(RegisterUserInputModel userInput)
        {
            var user = new User(userInput.Name, userInput.Email, userInput.Username, userInput.Password);
            
            await _authenticationRepository.Add(user);
            await _authenticationRepository.UnitOfWork.Commit();

            return Ok();
        }

        /// <summary>
        /// Verifica se o e-mail está sendo utilizado
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("verify/email")]
        public async Task<IActionResult> VerifyEmailExists([FromQuery] string email)
        {
            var inUse = await _authenticationRepository.VerifyEmailExistsAsync(email);

            if (inUse)
                return BadRequest(new { message = "Email address already in use" });

            return Ok();
        }

        /// <summary>
        /// Verifica se o username está sendo utilizado
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
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
