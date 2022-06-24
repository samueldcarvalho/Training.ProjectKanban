using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Training.Core.Data.Repositories
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task Add(T entity);
        Task Update(T entity);
        Task<T> GetById(int id);
    }
}
