using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Training.Core.Data.Repositories;
using Training.Kanban.Domain.Authentication.Models;
using Training.Kanban.Domain.Interfaces;
using Training.Kanban.Infraestructure.DataContexts.Authentication;

namespace Training.Kanban.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository, IRepository<User>
    {
        private readonly UserContext _context;
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
        }

        public User GetById(int id)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(u =>
                u.Id == id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
