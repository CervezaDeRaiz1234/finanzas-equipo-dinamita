using System;
using Finanzas2018.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Finanzas2018.Areas.Identity.IdentityHostingStartup))]
namespace Finanzas2018.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<Finanzas2018IdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("Finanzas2018IdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(
                    opt =>
                    {
                        opt.Password.RequiredLength = 3;
                        opt.Password.RequireLowercase = false;
                        opt.Password.RequireDigit = false;
                        opt.Password.RequireUppercase = false;
                        opt.Password.RequireNonAlphanumeric = false;

                    }
                )
                    .AddEntityFrameworkStores<Finanzas2018IdentityDbContext>();
            });
        }
    }
}