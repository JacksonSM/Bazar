using Bazar.Application.Services.Anuncio;
using Bazar.Application.Services.Anuncio.Contracts;
using Bazar.Application.Tools.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Bazar.Application;
public static class Bootstrapper
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddServices(services);
        AddUseCases(services);
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperConfig));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IAnuncioService, AnuncioService>()
                .AddScoped<IObterAnuncioService, ObterAnuncioService>();
    }
}
