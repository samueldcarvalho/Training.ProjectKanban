using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Kanban.Application.Interfaces;
using Training.Kanban.Application.Models.Views;
using Training.Kanban.Domain.Interfaces;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Application.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public UserQueries(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<JwtViewModel> AuthenticateUserByLogin(string username, string password)
        {
            try
            {
                User user = await _userRepository.GetByLogin(username, password);

                if (user == null)
                    return null;

                return new JwtViewModel
                {
                    User = new UserInfoViewModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Name = user.Name,
                    },
                    Token = _tokenService.GenerateToken(user)
                };
            }
            catch 
            {
                return null;
            }
        }

        public async Task<UserViewModel> GetUserById(int id)
        {
            if (id <= 0)
                return null;

            try
            {
                User user = await _userRepository.GetById(id);

                if (user == null)
                    return null;

                return new UserViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Teams = user.Teams,
                    Boards = user.Boards,
                    TeamLeaderIds = user.Teams
                            .Where(t => t.LeaderId == user.Id)
                            .Select(t => t.Id) ?? Enumerable.Empty<int>(),
                    BoardLeaderIds = user.Boards
                            .Where(b => b.LeaderId == user.Id)
                            .Select(b => b.Id) ?? Enumerable.Empty<int>(),
                };
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> VerifyEmailExists(string email) => 
            await _userRepository.VerifyEmailExistsAsync(email);

        public async Task<bool> VerifyUsernameExists(string username) => 
            await _userRepository.VerifyUsernameExistsAsync(username);
    }
}
