using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new();
                role.Name = "User";
                role.NormalizedName = "USER";

                roleManager.CreateAsync(role).Wait();
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new();
                role.Name = "Admin";
                role.NormalizedName = "Admin";

                roleManager.CreateAsync(role).Wait();
            }
        }

        public void SeedUsers()
        {
            if (userManager.FindByEmailAsync("usuario@localhost").Result is null)
            {
                ApplicationUser user = new();
                user.UserName = "usuario@localhost";
                user.Email = "usuario@localhost";
                user.NormalizedUserName = "USUARIO@LOCALHOST";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                user.SecurityStamp = Guid.NewGuid().ToString();

                var result = userManager.CreateAsync(user, "User@local123").Result;

                if (result.Succeeded)
                    userManager.AddToRoleAsync(user, "User").Wait();
            }

            if (userManager.FindByEmailAsync("admin@localhost").Result is null)
            {
                ApplicationUser user = new();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "admin@LOCALHOST";
                user.NormalizedEmail = "admin@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                user.SecurityStamp = Guid.NewGuid().ToString();

                var result = userManager.CreateAsync(user, "Admin@local123").Result;

                if (result.Succeeded)
                    userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}