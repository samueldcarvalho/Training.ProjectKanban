using Training.Authentication.API.Models;
using Training.Core.Domain.Models;

namespace Training.Authentication.API.Interfaces
{
    public interface IAuthenticationRepository
    {
        User GetByLogin(string username, string password);
        User GetById(int id);
    }
}
