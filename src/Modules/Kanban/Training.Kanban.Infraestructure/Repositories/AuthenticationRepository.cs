using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Kanban.Domain.Interfaces;
using Training.Kanban.Domain.Users;
using Training.Kanban.Infraestructure.Contexts;

namespace Training.Kanban.Infraestructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly KanbanDbContext _dbContext;

        public AuthenticationRepository(KanbanDbContext dbContext)
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

        public async Task<bool> VerifyEmailExistsAsync(string email)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => 
                    u.Email == email);

            return user != null;
        }

        public async Task<bool> VerifyUsernameExistsAsync(string username)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u =>
                    u.Username == username);

            return user != null;
        }
    }
}
