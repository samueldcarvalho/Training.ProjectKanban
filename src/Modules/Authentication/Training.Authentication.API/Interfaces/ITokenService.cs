using Training.Authentication.API.Models;

namespace Training.Authentication.API.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
