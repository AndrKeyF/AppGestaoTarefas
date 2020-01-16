using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas.Models
{
        public class EFGestaoTarefasRepository : IGestaoTarefasRepository
        {
            private GestaoTarefasDbContext db;

            public EFGestaoTarefasRepository(GestaoTarefasDbContext db)
            {
                this.db = db;
            }

            public IEnumerable<Funcionario> Funcionarios => db.Funcionario;

            public IEnumerable<Servico> Servicos => db.Servico;
    }
    
}
