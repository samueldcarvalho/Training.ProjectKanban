using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Core.Domain.Models;
using Training.Kanban.Domain.Interfaces;
using Training.Kanban.Infraestructure.Contexts;

namespace Training.Kanban.Infraestructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AuthenticationContext _dbContext;

        public AuthenticationRepository(AuthenticationContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<User> IAuthenticationRepository.GetByLogin(string username, string password) =>
            await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u =>
                    string.Equals(u.Username, username) && 
                    string.Equals(u.Password, password));

        async Task<User> IAuthenticationRepository.GetById(int id) =>
            await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u =>
                    u.Id == id);
       
        public Task<bool> Register(User user)
        {
            try
            {
                _dbContext.Users.AddAsync(user);
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}
