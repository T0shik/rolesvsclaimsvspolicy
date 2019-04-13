using Claims.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Claims;

namespace Claims
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var services = host.Services.CreateScope())
            {
                var dbContext = services.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userMgr = services.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                dbContext.Database.Migrate();

                var adminClaim = new Claim("Role", "Admin");
                var managerClaim = new Claim("Role", "Manager");
                var dateStartedClaim = new Claim("DateStarted", "01/01/2010");

                if (!dbContext.Users.Any(u => u.UserName == "admin@test.com"))
                {
                    var adminUser = new IdentityUser
                    {
                        UserName = "admin@test.com",
                        Email = "admin@test.com"
                    };
                    var result = userMgr.CreateAsync(adminUser, "password").GetAwaiter().GetResult();

                    userMgr.AddClaimAsync(adminUser, adminClaim).GetAwaiter().GetResult();
                    userMgr.AddClaimAsync(adminUser, managerClaim).GetAwaiter().GetResult();
                    userMgr.AddClaimAsync(adminUser, dateStartedClaim).GetAwaiter().GetResult();
                }
                else
                {
                    var adminUser = userMgr.FindByEmailAsync("admin@test.com").GetAwaiter().GetResult();

                    if (!userMgr.GetClaimsAsync(adminUser).GetAwaiter().GetResult().Any())
                    {
                        userMgr.AddClaimAsync(adminUser, adminClaim).GetAwaiter().GetResult();
                        userMgr.AddClaimAsync(adminUser, managerClaim).GetAwaiter().GetResult();
                        userMgr.AddClaimAsync(adminUser, dateStartedClaim).GetAwaiter().GetResult();
                    }
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
