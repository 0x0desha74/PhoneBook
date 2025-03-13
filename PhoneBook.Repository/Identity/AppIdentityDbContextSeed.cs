﻿using Microsoft.AspNetCore.Identity;
using PhoneBook.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Repository.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task RoleSeedAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "User", "Manager" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }



        public static async Task UserSeedAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Mustafa Elsayed",
                    Email = "mustafa.elsayed@gmail.com",
                    UserName = "mustafa.elsayed",
                    PhoneNumber = "0110110110",
                };
                await userManager.CreateAsync(user, "P@ssword123");
            }

        }
    }
}
