using System;
using System.Threading.Tasks;

namespace Training.Core.CQRS.Models
{
    public abstract class Command<T>
    {
        protected Task<bool> IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
