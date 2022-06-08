using Training.Authentication.API.Models;

namespace Training.Authentication.API.Interfaces
{
    public interface IUserRepository
    {
        User Get(string username, string password);
    }
}
