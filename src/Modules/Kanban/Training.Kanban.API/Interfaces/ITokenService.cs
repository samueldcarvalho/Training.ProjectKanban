using Training.Kanban.Domain.Users;

namespace Training.Kanban.API.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
