using Microsoft.AspNetCore.Identity;
using System;
using MyApplication.Core;
using MyApplication.Data.Entities;

namespace MyApplication.Web.Seed
{
    public static class Seed
    {
        public static void SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedCompanyAdminUser(userManager, roleManager);
            SeedUsers(userManager);
            //SeedCompany();

        }

        private static void SeedCompanyAdminUser(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            User model = new();
            if (userManager.FindByNameAsync("noemail@noemail.com").Result == null)
            {
                //Surat Company
                model = new User()
                {
                    FirstName = "Surat",
                    LastName = "Contact",
                    Email = "noemail@noemail.com",
                    UserName = "noemail@noemail.com",
                    EmailConfirmed = true,
                    CompanyId = 1
                };

                IdentityResult result = userManager.CreateAsync(model, "HelloWorld@12345").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(model, "Admin").Wait();
                }
            }

            if (userManager.FindByNameAsync("nocontact@nocontact.com").Result == null)
            {
                //Mumbai Company
                model = new User()
                {
                    FirstName = "Mumbai",
                    LastName = "Contact",
                    Email = "nocontact@nocontact.com",
                    UserName = "nocontact@nocontact.com",
                    EmailConfirmed = true,
                    CompanyId = 2
                };

                IdentityResult result = userManager.CreateAsync(model, "HelloWorld@12345").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(model, "Admin").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("SystemAdmin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "SystemAdmin"
                };
                roleManager.CreateAsync(role).Wait();
            }
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin"
                };
                roleManager.CreateAsync(role).Wait();
            }
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "User"
                };
                roleManager.CreateAsync(role).Wait();
            }
        }

        private static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync("sysadmin@localhost.com").Result == null)
            {
                User user = new User
                {
                    UserName = "sysadmin@localhost.com",
                    Email = "sysadmin@localhost.com",
                    FirstName = "System",
                    LastName = "Admin",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CompanyId = 1
                };

                IdentityResult result = userManager.CreateAsync
                (user, "HelloWorld@12345").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "SystemAdmin").Wait();
                }
            }


            #region Surat Company
            if (userManager.FindByNameAsync("admin@localhost.com").Result == null)
            {
                User user = new User
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com",
                    FirstName = "Demo",
                    LastName = "Admin",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CompanyId = 1
                };

                IdentityResult result = userManager.CreateAsync
                (user, "HelloWorld@12345").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByNameAsync("user1@localhost.com").Result == null)
            {
                User user = new User
                {
                    UserName = "user1@localhost.com",
                    Email = "user1@localhost.com",
                    FirstName = "Demo",
                    LastName = "User1",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CompanyId = 1
                };

                IdentityResult result = userManager.CreateAsync
                (user, "HelloWorld@12345").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (userManager.FindByNameAsync("user2@localhost.com").Result == null)
            {
                User user = new User
                {
                    UserName = "user2@localhost.com",
                    Email = "user2@localhost.com",
                    FirstName = "Demo",
                    LastName = "User2",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CompanyId = 1
                };

                IdentityResult result = userManager.CreateAsync
                (user, "HelloWorld@12345").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
            #endregion


            #region Mumbai Company
            if (userManager.FindByNameAsync("Mufaddal@saibex.co.in").Result == null)
            {
                User user = new User
                {
                    UserName = "Mufaddal@saibex.co.in",
                    Email = "Mufaddal@saibex.co.in",
                    FirstName = "Mufaddal",
                    LastName = "Admin",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CompanyId = 2
                };

                IdentityResult result = userManager.CreateAsync
                (user, "HelloWorld@12345").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByNameAsync("user1@serverhost.com").Result == null)
            {
                User user = new User
                {
                    UserName = "user1@serverhost.com",
                    Email = "user1@serverhost.com",
                    FirstName = "Demo",
                    LastName = "User1",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CompanyId = 2
                };

                IdentityResult result = userManager.CreateAsync
                (user, "HelloWorld@12345").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (userManager.FindByNameAsync("user2@serverhost.com").Result == null)
            {
                User user = new User
                {
                    UserName = "user2@serverhost.com",
                    Email = "user2@serverhost.com",
                    FirstName = "Demo",
                    LastName = "User2",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CompanyId = 2
                };

                IdentityResult result = userManager.CreateAsync
                (user, "HelloWorld@12345").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
            #endregion
        }

    }
}