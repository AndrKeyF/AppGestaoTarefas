using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas.Models
{
    public static class SeedData
    {


        internal static void Populate(IServiceProvider applicationServices)
        {
            using (var serviceScope = applicationServices.CreateScope())
            {

                var db = serviceScope.ServiceProvider.GetService<GestaoTarefasDbContext>();

                SeedFuncionarios(db);

            }
        }

        private static void SeedEstadoPedidoTrocas(GestaoTarefasDbContext db)
        {
            if (db.Funcionario.Any()) return;

            db.Funcionario.AddRange(

                new Funcionario { Nome = "André Teixeira", Telemovel = "912345678", Email = "mail@mail.pt", CC = "12345678", CargoId = 1 }

                );

            db.SaveChanges();
        }
    }
}
        

