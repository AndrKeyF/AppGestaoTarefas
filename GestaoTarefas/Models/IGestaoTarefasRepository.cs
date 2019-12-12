using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas.Models
{
    public class IGestaoTarefasRepository
    {
        IEnumerable<Funcionario> Funcionarios { get; }
    }
}
