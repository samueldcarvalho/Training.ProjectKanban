using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Core.Data.Repositories;
using Training.Kanban.Domain.Interfaces;
using Training.Kanban.Domain.Users;
using Training.Kanban.Infraestructure.Contexts;

namespace Training.Kanban.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IUnitOfWork UnitOfWork => _context;
        private readonly KanbanDbContext _context;

        public UserRepository(KanbanDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<User> GetByLogin(string username, string password) =>
            await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u =>
                    string.Equals(u.Username, username) && 
                    string.Equals(u.Password, password));

        public async Task<User> GetById(int id) =>
            await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u =>
                    u.Id == id);
       
        public async Task Add(User user) =>   
            await _context.Users.AddAsync(user);
        public Task Update(User entity) =>
            Task.FromResult(_context.Users.Update(entity));
        
        public async Task<bool> VerifyEmailExistsAsync(string email)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => 
                    u.Email == email);

            return user != null;
        }

        public async Task<bool> VerifyUsernameExistsAsync(string username)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Username == username);

            return user != null;
        }

        public void Dispose() { }
    }
}
