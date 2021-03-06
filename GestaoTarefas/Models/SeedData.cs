﻿using Microsoft.AspNetCore.Identity;
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
        private const string ANDRE_ROLE = "andr";
        private const string CRIS_ROLE = "cris";
        private const string TIAGO_ROLE = "tig";

        public static void Populate(GestaoTarefasDbContext db)
        {
            PopulateCargo(db);
            PopulateServico(db);
            PopulateDepartamento(db);
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
                new Cargo { Nome = "Segurança"  },
                new Cargo { Nome = "Rececionista" },
                new Cargo { Nome = "Gestor" },
                new Cargo { Nome = "Cozinheira" },
                new Cargo {Nome = "Auxiliar de Limpeza"}

            );

            db.SaveChanges();
        }

        private static void PopulateServico(GestaoTarefasDbContext db)
        {
            if (db.Servico.Any()) return;

            db.Servico.AddRange(
                new Servico { Nome = "Secretaria" },
                new Servico { Nome = "Direção" },
                new Servico { Nome = "Bar" },
                new Servico { Nome = "Cantina" }
                

            );

            db.SaveChanges();
        }

        private static void PopulateDepartamento(GestaoTarefasDbContext db)
        {
            if (db.Departamento.Any()) return;

            db.Departamento.AddRange(
                new Departamento { Nome = "Informática" },
                new Departamento { Nome = "Gestão" },
                new Departamento { Nome = "Civil" },
                new Departamento { Nome = "Direção" },
                new Departamento { Nome = "Desporto" },
                new Departamento { Nome = "Enfermagem" },
                new Departamento { Nome = "Multimedia" },
                new Departamento { Nome = "Contabilidade"}

            );

            db.SaveChanges();
        }

        private static void PopulateFuncionario(GestaoTarefasDbContext db)
        {

            if (db.Funcionario.Any()) return;

            Cargo cargo = db.Cargo
                .FirstOrDefault(m => m.Nome == "Professor");
            Departamento departamento = db.Departamento
               .FirstOrDefault(d => d.Nome == "Informática");
            if (cargo == null || departamento == null)
            {
                db.Cargo.AddRange(
                cargo = new Cargo { Nome = "Professor" });

                db.Departamento.AddRange(
                departamento = new Departamento { Nome = "Informática" });
                db.SaveChanges();
            }

            db.Funcionario.AddRange(
                new Funcionario { Nome = "André Teixeira", Telemovel = "912345678", CC = "12345678", Email = "mail@mail.pt", CargoId = cargo.CargoId, DepartamentoId = departamento.DepartamentoId },
                new Funcionario { Nome = "Filipe Teixeira", Telemovel = "912345678", CC = "12345678", Email = "mail1@mail.pt", CargoId = cargo.CargoId, DepartamentoId = departamento.DepartamentoId },
                new Funcionario { Nome = "Paulo Teixeira", Telemovel = "912345678", CC = "12345678", Email = "mail2@mail.pt", CargoId = cargo.CargoId, DepartamentoId = departamento.DepartamentoId }
                        );

            db.SaveChanges();
//Cargo Diretor
             Cargo cargo1 = db.Cargo
                  .FirstOrDefault(m => m.Nome == "Diretor");
            Departamento departamento1 = db.Departamento
                  .FirstOrDefault(m => m.Nome == "Informática");
            if (cargo1 == null || departamento1 == null)
             {
                db.Cargo.AddRange(
                cargo1 = new Cargo { Nome = "Diretor" });

                db.Departamento.AddRange(
                departamento1 = new Departamento { Nome = "Informática" });

                 db.SaveChanges();
              }


                 db.Funcionario.AddRange(
                    new Funcionario { Nome = "Cristiana Cardoso", Telemovel = "912345678", CC = "12345678", Email = "mail3@mail.pt", CargoId = cargo1.CargoId, DepartamentoId = departamento1.DepartamentoId }  
                 );
            db.SaveChanges();
            //Cargo Presidente
            Cargo cargo2 = db.Cargo
                  .FirstOrDefault(m => m.Nome == "Presidente");
              Departamento departamento2 = db.Departamento
                  .FirstOrDefault(m => m.Nome == "Secretaria");

            if (cargo2 == null || departamento2 == null)
              {
                db.Cargo.AddRange(
                cargo2 = new Cargo { Nome = "Presidente" });

                db.Departamento.AddRange(
                departamento2 = new Departamento { Nome = "Secretaria" });

               db.SaveChanges();
              }

                      db.Funcionario.AddRange(
                         new Funcionario { Nome = "Tiago Santos", Telemovel = "912345678", CC = "12345678", Email = "mail4@mail.pt", CargoId = cargo2.CargoId, DepartamentoId = departamento2.DepartamentoId }
                      );
            db.SaveChanges();
            //Cargo Auxiliar

            Cargo cargo3 = db.Cargo
                 .FirstOrDefault(m => m.Nome == "Auxiliar de Limpeza");
            Departamento departamento3 = db.Departamento
               .FirstOrDefault(m => m.Nome == "Informática");
            if (cargo3 == null || departamento3 == null)
            {
                db.Cargo.AddRange(
                cargo3 = new Cargo { Nome = "Auxiliar de Limpeza" });
                db.Departamento.AddRange(
                departamento3 = new Departamento { Nome = "Informática" });

                db.SaveChanges();
            }
             
                db.Funcionario.AddRange(
                   new Funcionario { Nome = "Paula Pereira", Telemovel = "912345678", CC = "12345678", Email = "mail5@mail.pt", CargoId = cargo3.CargoId, DepartamentoId = departamento3.DepartamentoId },
                   new Funcionario { Nome = "Ana Vitória", Telemovel = "912345678", CC = "12345678", Email = "mail6@mail.pt", CargoId = cargo3.CargoId, DepartamentoId = departamento3.DepartamentoId },
                   new Funcionario { Nome = "Rui Carvalho", Telemovel = "912345678", CC = "12345678", Email = "mail7@mail.pt", CargoId = cargo3.CargoId, DepartamentoId = departamento3.DepartamentoId });

            db.SaveChanges();

            Cargo cargo3v2 = db.Cargo
                .FirstOrDefault(m => m.Nome == "Auxiliar de Limpeza");
            Departamento departamento3v2 = db.Departamento
                .FirstOrDefault(m => m.Nome == "Direção");
            if (cargo3v2 == null || departamento3v2 == null)
            {
                    db.Cargo.AddRange(
                    cargo3v2 = new Cargo { Nome = "Auxiliar de Limpeza" });

                    db.Departamento.AddRange(
                    departamento3v2 = new Departamento { Nome = "Direção" });
                db.SaveChanges();
            }

                db.Funcionario.AddRange(
                   new Funcionario { Nome = "Américo Costa", Telemovel = "912345678", CC = "12345678", Email = "mail8@mail.pt", CargoId = cargo3v2.CargoId, DepartamentoId = departamento3v2.DepartamentoId },
                   new Funcionario { Nome = "Laurinda Rocha", Telemovel = "912345678", CC = "12345678", Email = "mail9@mail.pt", CargoId = cargo3v2.CargoId, DepartamentoId = departamento3v2.DepartamentoId });
            db.SaveChanges();

            //Cargo Secretário
            Cargo cargo4 = db.Cargo
                .FirstOrDefault(m => m.Nome == "Secretário");
            Departamento departamento4 = db.Departamento
                .FirstOrDefault(m => m.Nome == "Direção");

            if (cargo4 == null || departamento4 == null)
            {
                 db.Cargo.AddRange(
                 cargo4 = new Cargo { Nome = "Secretário" });

                 db.Departamento.AddRange(
                 departamento4 = new Departamento { Nome = "Direção" });
                
                db.SaveChanges();
            }
                
                db.Funcionario.AddRange(
                   new Funcionario { Nome = "Paulo Cardoso", Telemovel = "912345678", CC = "12345678", Email = "mailjklh@mail.pt", CargoId = cargo4.CargoId, DepartamentoId = departamento4.DepartamentoId },
                   new Funcionario { Nome = "Amilcar Santos", Telemovel = "912345678", CC = "12345678", Email = "mail999@mail.pt", CargoId = cargo4.CargoId, DepartamentoId = departamento4.DepartamentoId },
                   new Funcionario { Nome = "Vera Orquidea", Telemovel = "912345678", CC = "12345678", Email = "mail121@mail.pt", CargoId = cargo4.CargoId, DepartamentoId = departamento4.DepartamentoId },
                   new Funcionario { Nome = "Roberto Adelino", Telemovel = "912345678", CC = "12345678", Email = "mail500@mail.pt", CargoId = cargo4.CargoId, DepartamentoId = departamento4.DepartamentoId },
                   new Funcionario { Nome = "Amélia Chique", Telemovel = "912345678", CC = "12345678", Email = "mailwafaf@mail.pt", CargoId = cargo4.CargoId, DepartamentoId = departamento4.DepartamentoId }
            );

                db.SaveChanges();
                                    
        }




        ////////////User Login
        public static async Task PopulateUsersAsync(UserManager<IdentityUser> userManager)  //names
        {
            const string ANDRE_USERNAME = "andre@ipg.pt";
            const string ANDRE_PASSWORD = "Secret123$";

            const string CRIS_USERNAME = "cristiana@ipg.pt";
            const string CRIS_PASSWORD = "Secret123$";


            const string TIAGO_USERNAME = "tiago@ipg.pt";
            const string TIAGO_PASSWORD = "Secret123$";


            IdentityUser user = await userManager.FindByNameAsync(ANDRE_USERNAME);//await -esperar
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = ANDRE_USERNAME,
                    Email = ANDRE_USERNAME
                };

                await userManager.CreateAsync(user, ANDRE_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(user, ANDRE_ROLE))
            {
                await userManager.AddToRoleAsync(user, ANDRE_ROLE);
            }

            user = await userManager.FindByNameAsync(ANDRE_USERNAME);



            user = await userManager.FindByNameAsync(CRIS_USERNAME);

            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = CRIS_USERNAME,
                    Email = CRIS_USERNAME
                };

                await userManager.CreateAsync(user, CRIS_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(user, CRIS_ROLE))
            {
                await userManager.AddToRoleAsync(user, CRIS_ROLE);
            }



            user = await userManager.FindByNameAsync(TIAGO_USERNAME);

            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = TIAGO_USERNAME,
                    Email = TIAGO_USERNAME
                };

                await userManager.CreateAsync(user, TIAGO_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(user, TIAGO_ROLE))
            {
                await userManager.AddToRoleAsync(user, TIAGO_ROLE);
            }
        }

        public static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
        {


            if (!await roleManager.RoleExistsAsync(ANDRE_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(ANDRE_ROLE));
            }

            if (!await roleManager.RoleExistsAsync(CRIS_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(CRIS_ROLE));
            }

            if (!await roleManager.RoleExistsAsync(TIAGO_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(TIAGO_ROLE));
            }
        }
    

    }
}
        

