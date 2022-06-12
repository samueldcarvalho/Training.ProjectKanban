using Training.Authentication.API.Models;
using Training.Core.Domain.Models;
using Training.Kanban.Domain.Users;

namespace Training.Authentication.API.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
