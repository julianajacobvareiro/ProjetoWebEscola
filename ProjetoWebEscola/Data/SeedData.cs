using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using ProjetoWebEscola.Models;

namespace ProjetoWebEscola.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Administrator", "Funcionario", "Aluno", "Anonymous" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var user = await userManager.FindByEmailAsync("admin@example.com");
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                };
                await userManager.CreateAsync(user, "Admin@123");
            }

            await userManager.AddToRoleAsync(user, "Administrator");
        }
    }
}
