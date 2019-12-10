using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestaoTarefas.Models;

namespace GestaoTarefas.Models
{
    public class GestaoTarefasDbContext : DbContext
    {
        public GestaoTarefasDbContext (DbContextOptions<GestaoTarefasDbContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoTarefas.Models.Cargo> Cargo { get; set; }

        public DbSet<Funcionario> Funcionario { get; set; }

        public DbSet<GestaoTarefas.Models.Servico> Servico { get; set; }
    }
}
