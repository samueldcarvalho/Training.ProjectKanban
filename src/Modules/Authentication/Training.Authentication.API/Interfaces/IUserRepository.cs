using Training.Authentication.API.Models;

namespace Training.Authentication.API.Interfaces
{
    public interface IUserRepository
    {
        User GetByLogin(string username, string password);
        User GetById(int id);
    }
}
