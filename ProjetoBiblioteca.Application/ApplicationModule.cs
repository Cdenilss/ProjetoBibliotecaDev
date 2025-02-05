using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoBiblioteca.Application.Services;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddServices();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBookServices, BookServices>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ILoanService, LoanServices>();
        return services;
    }
}