using Training.Core.Domain.Models;

namespace Training.Kanban.Domain.Interfaces
{
    public interface IAuthenticationRepository
    {
        User GetByLogin(string username, string password);
        User GetById(int id);
    }
}
