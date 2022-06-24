using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Training.Core.CQRS.Models;
using Training.Core.CQRS.Services;
using Training.Kanban.API.Interfaces;
using Training.Kanban.Application.Commands.Users;
using Training.Kanban.Application.Models.Inputs;
using Training.Kanban.Application.Models.Views;
using Training.Kanban.Domain.Interfaces;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.API.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler _mediator;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IUserRepository authenticationRepository, ITokenService tokenService, IMediatorHandler mediator)
        {
            _userRepository = authenticationRepository;
            _tokenService = tokenService;
            _mediator = mediator;
        }

        /// <summary>
        /// Autentica a sessão, com dados de login e retorna JWT
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns></returns>
        [HttpPost("auth")]
        public async Task<ActionResult<JwtViewModel>> AuthenticateAsync([FromBody] LoginInputModel loginData)
        {
            var user = await _userRepository.GetByLogin(loginData.Username, loginData.Password);

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
            var user = await _userRepository.GetById(userId);

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
            CommandResponse<bool> commandResponse = await _mediator
                .SendCommand(new RegisterUserCommand(
                        userInput.Name,
                        userInput.Email,
                        userInput.Username,
                        userInput.Password
                    ));

            if (commandResponse.Result == false)
                return BadRequest();

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
            var inUse = await _userRepository.VerifyEmailExistsAsync(email);

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
            var inUse = await _userRepository.VerifyUsernameExistsAsync(username);

            if (inUse)
                return BadRequest(new { message = "Username already in use" });

            return Ok();
        }
    }
}
