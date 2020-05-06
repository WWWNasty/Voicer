using DataAccessLayer.Models.Users;
using Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(WebApplication.Areas.Identity.IdentityHostingStartup))]

namespace WebApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDefaultIdentity<User>(options =>
                    {
                        options.SignIn.RequireConfirmedAccount = true;
                        options.Password.RequireDigit = false;
                        options.Password.RequiredLength = 1;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                        options.Password.RequiredUniqueChars = 0;
                        options.Password.RequireNonAlphanumeric = false;
                    })
                    .AddEntityFrameworkStores<VotingDbContext>();
            });
        }
    }
}