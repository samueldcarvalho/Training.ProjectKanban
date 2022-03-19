using Training.Kanban.Domain.Authentication.Models;

namespace Training.Kanban.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Add(User entity);
        void Update(User entity);
        User GetById(int id);
        void Dispose();
    }
}