using Bazar.Domain.Interfaces;
using Bazar.Domain.Interfaces.Repositories;
using Bazar.Infrastructure.Context;
using Bazar.Infrastructure.Identity;
using Bazar.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bazar.Infrastructure;
public static class Bootstrapper
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddContext(services, configuration);
        AddRepositories(services);
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }


    private static void AddContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionString"];

        services.AddDbContext<BazarDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddDefaultIdentity<ApplicationUser>(opt =>
        {
            opt.User.RequireUniqueEmail = true;
        }).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<BazarDbContext>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IAnuncioRepository, AnuncioRepository>();
    }

}
