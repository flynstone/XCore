using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;
using XCore.Idp.Models;

namespace XCore.Idp
{
    public class SeedUserData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<UserContext>(options =>
               options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole>(o => {
                o.Password.RequireDigit = false;
                o.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<UserContext>()
              .AddDefaultTokenProviders();

            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            using IServiceScope scope = serviceProvider
                .GetRequiredService<IServiceScopeFactory>().CreateScope();
            CreateUser(scope, "Admin", "User", "Fake Boulevard 323",
                "ccb5e01f-1e6c-4412-9efc-98aac4f29f02", "P@ssword123",
                "Admin", "admin@mail.com");

            CreateUser(scope, "Guest", "User", "Guest's Avenue 214",
                "3071cbfb-95f8-499c-801c-ee61d815060b", "P@ssword123",
                "Guest", "guest@mail.com");
        }

        private static void CreateUser(IServiceScope scope, string name, string lastName,
            string address, string id, string password, string role, string email)
        {
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var user = userMgr.FindByNameAsync(email).Result;
            if (user == null)
            {
                user = new User
                {
                    UserName = email,
                    Email = email,
                    FirstName = name,
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
