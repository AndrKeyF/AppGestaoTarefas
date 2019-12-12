using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas.Models
{
    public class PaginationViewModel
    {
        public IEnumerable<Funcionario> Funcionarios { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int FirstPageShow { get; set; }
        public int LastPageShow { get; set; }
    }
}
