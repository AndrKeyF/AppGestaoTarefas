using Microsoft.AspNetCore.Identity;
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

        

