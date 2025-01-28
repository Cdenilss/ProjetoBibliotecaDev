using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoBiblioteca.Application.Services;

public static class ApplicationModule
{
    public static IServiceCollection AddAppplication(this IServiceCollection services)
    {
        services
            .AddServices();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBookServices, BookServices>();
        return services;
    }
}