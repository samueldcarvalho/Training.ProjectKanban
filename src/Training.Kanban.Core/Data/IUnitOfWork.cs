using System.Threading.Tasks;

namespace Training.Kanban.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }

}
