using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas.Models
{
        public class EFSportsStoreRepository : IGestaoTarefasRepository
        {
            private GestaoTarefasDbContext db;

            public EFSportsStoreRepository(GestaoTarefasDbContext db)
            {
                this.db = db;
            }

            public IEnumerable<Funcionario> Funcionarios => db.Funcionario;
        }
    
}
