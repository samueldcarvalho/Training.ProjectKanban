using System.Threading.Tasks;
using Training.Core.Data.Repositories;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByLogin(string username, string password);
        Task<bool> VerifyEmailExistsAsync(string email);
        Task<bool> VerifyUsernameExistsAsync(string username);
    }
}
