using System;
using Training.Kanban.Core.Domain.Interfaces;

namespace Training.Kanban.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }

}
