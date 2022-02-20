using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Kanban.Domain.Models.Enumerators
{
    public enum TipoInteracaoEnum
    {
        CRIACAO,
        ALTERACAO,
        BLOQUEIO,
        REMOCAO,
        TRANSFERENCIA,
        MENCAO
    }
}
