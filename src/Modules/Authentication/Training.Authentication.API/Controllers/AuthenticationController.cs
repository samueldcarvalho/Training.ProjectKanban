﻿using Microsoft.AspNetCore.Mvc;
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
            var user = _userRepository.GetByLogin(loginData.Username, loginData.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

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

        [HttpGet("authenticate/{userId}")]
        public async Task<ActionResult<UserViewModel>> GetUserInformationAsync(int userId)
        {
            var user = _userRepository.GetById(userId);

            if (user == null)
                return NotFound(new { message = "Usuário não encontrado" });

            return Json(user);
        }
    }
}