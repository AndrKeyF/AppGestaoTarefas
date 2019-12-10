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
            PopulateFuncionario(db);
            PopulateCargo(db);
        }

        private static void PopulateCargo(GestaoTarefasDbContext db)
        {
            if (db.Cargo.Any()) return;

            db.Cargo.AddRange(
                new Cargo { CargoId = 1, Nome = "Professor" },
                new Cargo { CargoId = 2, Nome = "Diretor" },
                new Cargo { CargoId = 3, Nome = "Presidente" },
                new Cargo { CargoId = 4, Nome = "Vice-Presidente" },
                new Cargo { CargoId = 5, Nome = "Secretário" },
                new Cargo { CargoId = 6, Nome = "Tesoureiro" },
                new Cargo { CargoId = 7, Nome = "Auxiliar de Limpeza"}

            );

            db.SaveChanges();
        }
        private static void PopulateFuncionario(GestaoTarefasDbContext db)
        {
            if (db.Funcionario.Any()) return;

            db.Funcionario.AddRange(
                new Funcionario { Nome = "André Teixeira", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = 1},
                new Funcionario { Nome = "Filipe Teixeira", Telemovel = "912345678", CC = "12345678", Email = "mail1@mail.pt", CargoId = 2},
                new Funcionario { Nome = "Paulo Teixeira", Telemovel = "912345678", CC = "12345678", Email = "mail2@mail.pt", CargoId = 5}

            );

            db.SaveChanges();
        }

    }
}
        

