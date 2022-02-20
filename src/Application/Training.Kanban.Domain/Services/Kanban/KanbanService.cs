using System.Threading.Tasks;
using Training.Kanban.Domain.Models.Entities;
using Training.Kanban.Domain.Repositories;

namespace Training.Kanban.Domain.Services.Kanban
{
    class KanbanService : IKanbanService
    {
        private readonly IKanbanRepository _kanbanRepository;

        public KanbanService(IKanbanRepository kanbanRepository)
        {
            _kanbanRepository = kanbanRepository;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
