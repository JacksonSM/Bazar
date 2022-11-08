using Bazar.Application.Services.Mappings;
using Bazar.Application.UseCase.Anuncio.Criar;
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
        services.AddScoped<ICriarAnuncioUseCase, CriarAnuncioUseCase>();
    }
}
