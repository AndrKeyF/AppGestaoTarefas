using Microsoft.EntityFrameworkCore;
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
            PopulateCargo(db);
            PopulateFuncionario(db);

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
        
        
        private static void PopulateFuncionario(GestaoTarefasDbContext db)
        {

            if (db.Funcionario.Any()) return;

            Cargo cargo = db.Cargo
                .FirstOrDefault(m => m.Nome == "Professor");
            if (cargo == null)
            {
                db.Cargo.AddRange(
                cargo = new Cargo { Nome = "Professor" }
 
                );
                db.SaveChanges();
            }

            db.Funcionario.AddRange(
                new Funcionario { Nome = "André Teixeira", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo.CargoId },
                new Funcionario { Nome = "Filipe Teixeira", Telemovel = "912345678", CC = "12345678", Email = "mail1@mail.pt", CargoId = cargo.CargoId },
                new Funcionario { Nome = "Paulo Teixeira", Telemovel = "912345678", CC = "12345678", Email = "mail2@mail.pt", CargoId = cargo.CargoId }
            );

            //Cargo Diretor
            Cargo cargo1 = db.Cargo
               .FirstOrDefault(m => m.Nome == "Diretor");
            if (cargo1 == null)
            {
                db.Cargo.AddRange(
                cargo1 = new Cargo { Nome = "Diretor" }

                );
                db.SaveChanges();
            }

            db.Funcionario.AddRange(
                new Funcionario { Nome = "Cristiana Cardoso", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo1.CargoId }  
            );

            //Cargo Presidente
            Cargo cargo2 = db.Cargo
               .FirstOrDefault(m => m.Nome == "Presidente");
            if (cargo2 == null)
            {
                db.Cargo.AddRange(
                cargo2 = new Cargo { Nome = "Presidente" }

                );
                db.SaveChanges();
            }

            db.Funcionario.AddRange(
                new Funcionario { Nome = "Tiago Santos", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo2.CargoId }
            );

            //Cargo Auxiliar

            Cargo cargo3 = db.Cargo
               .FirstOrDefault(m => m.Nome == "Auxiliar de Limpeza");
            if (cargo3 == null)
            {
                db.Cargo.AddRange(
                cargo3 = new Cargo { Nome = "Auxiliar de Limpeza" }

                );
                db.SaveChanges();
            }

            db.Funcionario.AddRange(
                new Funcionario { Nome = "Paula Pereira", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo3.CargoId },
                new Funcionario { Nome = "Ana Vitória", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo3.CargoId },
                new Funcionario { Nome = "Rui Carvalho", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo3.CargoId },
                new Funcionario { Nome = "Américo Costa", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo3.CargoId },
                new Funcionario { Nome = "Laurinda Rocha", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo3.CargoId }

            );

            db.SaveChanges();

            //Cargo Secretário
            Cargo cargo4 = db.Cargo
               .FirstOrDefault(m => m.Nome == "Secretário");
            if (cargo4 == null)
            {
                db.Cargo.AddRange(
                cargo4 = new Cargo { Nome = "Secretário" }

                );
                db.SaveChanges();
            }

            db.Funcionario.AddRange(
                new Funcionario { Nome = "Paulo Cardoso", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo4.CargoId },
                new Funcionario { Nome = "Amilcar Santos", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo4.CargoId },
                new Funcionario { Nome = "Vera Orquidea", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo4.CargoId },
                new Funcionario { Nome = "Roberto Adelino", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo4.CargoId },
                new Funcionario { Nome = "Amélia Chique", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo4.CargoId }

            );

            db.SaveChanges();
        }

    }
}
        

