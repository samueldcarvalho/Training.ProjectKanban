using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Training.Core.CQRS.Models;
using Training.Core.CQRS.Services;
using Training.Kanban.Application.Commands.Users;
using Training.Kanban.Application.Interfaces;
using Training.Kanban.Application.Models.Inputs;
using Training.Kanban.Application.Models.Views;

namespace Training.Kanban.API.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : Controller
    {
        private readonly IMediatorHandler _mediator;
        private readonly IUserQueries _userQueries;

        public AuthenticationController(IMediatorHandler mediator, IUserQueries userQueries)
        {
            _mediator = mediator;
            _userQueries = userQueries;
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<bool>> RegisterUserAsyc(RegisterUserInputModel userInput)
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
        /// Autentica a sessão, com dados de login e retorna JWT
        /// </summary>
        /// <param name="loginData"></param>
        /// <returns></returns>
        [HttpPost("auth")]
        public async Task<ActionResult<JwtViewModel>> AuthenticateByLoginAsync([FromBody]LoginInputModel loginData)
        {
            JwtViewModel jwt = await _userQueries
                .AuthenticateUserByLogin(
                    loginData.Username, 
                    loginData.Password
                    );

            if (jwt == null)
                return Unauthorized();

            return Ok(jwt);
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
            UserViewModel user = await _userQueries.GetUserById(userId);

            if (user == null)
                return Unauthorized(new { message = "Usuário não encontrado" });

            return Json(user);
        }


        /// <summary>
        /// Verifica se o e-mail está sendo utilizado
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("verify/email")]
        public async Task<IActionResult> VerifyEmailExists([FromQuery] string email)
        {
            try
            {
                bool inUse = await _userQueries.VerifyEmailExists(email);

                if (inUse)
                    return BadRequest(new { message = "Email address already in use" });

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Verifica se o username está sendo utilizado
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("verify/username")]
        public async Task<IActionResult> VerifyUsernameExists([FromQuery] string username)
        {
            try
            {
                bool inUse = await _userQueries.VerifyUsernameExists(username);

                if (inUse)
                    return BadRequest(new { message = "Username already in use" });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
