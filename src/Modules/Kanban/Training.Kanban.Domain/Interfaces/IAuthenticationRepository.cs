using System.Threading.Tasks;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<User> GetByLogin(string username, string password);
        Task<User> GetById(int id);
        Task<bool> Register(User user);
    }
}
