using Bazar.Domain.Interfaces;
using Bazar.Domain.Interfaces.Repositories;
using Bazar.Infrastructure.Context;
using Bazar.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
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
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IAnuncioRepository, AnuncioRepository>();
    }

}
