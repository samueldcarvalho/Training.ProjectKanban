using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Core.CQRS.Models;

namespace Training.Core.CQRS.Services
{
    public interface IMediatorHandler
    {
        public Task<CommandResponse<T>> SendCommand<T>(Command<T> command);
    }
}
