using System.Collections.Immutable;
using Microsoft.Extensions.DependencyInjection;
using ProjetoBiblioteca.Application.Commands.BookCommands.InsertBook;

namespace ProjetoBiblioteca.Application.Services;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddServices()
            .AddHandlers();
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBookServices, BookServices>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ILoanService, LoanServices>();
        return services;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertBookCommand>()
        );
        return services;
    }
}