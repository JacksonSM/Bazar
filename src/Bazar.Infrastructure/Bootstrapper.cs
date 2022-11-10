using Bazar.Domain.Interfaces;
using Bazar.Domain.Interfaces.Repositories;
using Bazar.Infrastructure.Context;
using Bazar.Infrastructure.Identity;
using Bazar.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bazar.Domain.Account;
using Bazar.Infrastructure.Identity.Services;

namespace Bazar.Infrastructure;
public static class Bootstrapper
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddContext(services, configuration);
        AddRepositories(services);
        AddIdentity(services);
    }


    private static void AddContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionString"];

        services.AddDbContext<BazarDbContext>(options =>
            options.UseSqlite(connectionString));

    }
    private static void AddIdentity(IServiceCollection services)
    {
        services.AddDefaultIdentity<ApplicationUser>(opt =>
        {
            opt.User.RequireUniqueEmail = true;
        }).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<BazarDbContext>();

        services.AddScoped<IUsuarioLogado, UsuarioLogado>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IAnuncioRepository, AnuncioRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

}
