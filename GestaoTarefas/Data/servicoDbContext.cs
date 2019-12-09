using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestaoTarefas.Models
{
    public class servicoDbContext : DbContext
    {
        public servicoDbContext (DbContextOptions<servicoDbContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoTarefas.Models.Servico> Servico { get; set; }
    }
}
