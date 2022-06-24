using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Kanban.Application.Models.Views;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Application.Interfaces
{
    public interface IUserQueries
    {
        Task<JwtViewModel> AuthenticateUserByLogin(string username, string password);
        Task<UserViewModel> GetUserById(int id);
        Task<bool> VerifyEmailExists(string email);
        Task<bool> VerifyUsernameExists(string username);
    }
}
