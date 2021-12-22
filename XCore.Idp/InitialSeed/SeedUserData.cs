using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using XCore.Idp.Models;

namespace XCore.Idp.InitialSeed
{
    public class SeedUserData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<UserContext>()
            .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    CreateUser(scope, "Julien", "Lacroix", "369 Fake Street",
                        "5c6a3394-1a64-4b1a-836d-5f0a21bfd222", "Vol1989stone!",
                        "Admin", "flynstone@live.ca");

                    CreateUser(scope, "Guest", "User", "963 Visitor's Boulevard",
                        "2dbf969c-0f3f-492b-bf1e-4ae9ff69280c", "Guest_012",
                        "Guest", "flynstone@x-coreweb.com");
                }
            }
        }

        private static void CreateUser(IServiceScope scope, string firstName, string lastName, string address, string id, string password, string role, string email)
        {
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var user = userMgr.FindByNameAsync(email).Result;
            if (user == null)
            {
                user = new User
                {
                    UserName = email,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    Id = id
                };
                var result = userMgr.CreateAsync(user, password).Result;
                CheckResult(result);

                result = userMgr.AddToRoleAsync(user, role).Result;
                CheckResult(result);

                result = userMgr.AddClaimsAsync(user, new Claim[]
                {
                    new Claim(JwtClaimTypes.GivenName, user.FirstName),
                    new Claim(JwtClaimTypes.FamilyName, user.LastName),
                    new Claim(JwtClaimTypes.Role, role),
                    new Claim(JwtClaimTypes.Address, user.Address)
                }).Result;
                CheckResult(result);
            }
        }

        private static void CheckResult(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
        }
    }
}
