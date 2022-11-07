using Bazar.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bazar.Infrastructure;
public static class Bootstrapper
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddContext(services, configuration);
    }

    private static void AddContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionString"];

        services.AddDbContext<BazarDbContext>(options =>
            options.UseSqlite(connectionString));
    }
}
