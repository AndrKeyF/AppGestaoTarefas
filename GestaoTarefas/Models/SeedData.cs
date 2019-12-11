using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas.Models
{
    public static class SeedData
    {
        public static void Populate(GestaoTarefasDbContext db)
        {
           // PopulateFuncionario(db);
            PopulateCargo(db);
        }

        private static void PopulateCargo(GestaoTarefasDbContext db)
        {
            if (db.Cargo.Any()) return;

            db.Cargo.AddRange(
                new Cargo {Nome = "Professor" },
                new Cargo {Nome = "Diretor" },
                new Cargo {Nome = "Presidente" },
                new Cargo {Nome = "Vice-Presidente" },
                new Cargo {Nome = "Secretário" },
                new Cargo {Nome = "Tesoureiro" },
                new Cargo {Nome = "Auxiliar de Limpeza"}

            );

            db.SaveChanges();
        }
        
        /*
        private static void PopulateFuncionario(GestaoTarefasDbContext db)
        {
            if (db.Funcionario.Any()) return;

            db.Funcionario.AddRange(
                new Funcionario { Nome = "André Teixeira", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = 1},
                new Funcionario { Nome = "Filipe Teixeira", Telemovel = "912345678", CC = "12345678", Email = "mail1@mail.pt", CargoId = 2},
                new Funcionario { Nome = "Paulo Teixeira", Telemovel = "912345678", CC = "12345678", Email = "mail2@mail.pt", CargoId = 5}

            );

            db.SaveChanges();
        }*/

    }
}
        

