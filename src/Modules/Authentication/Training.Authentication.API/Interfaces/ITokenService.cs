using Training.Authentication.API.Models;
using Training.Core.Domain.Models;

namespace Training.Authentication.API.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
