using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Kanban.Domain.Users;

namespace Training.Kanban.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
