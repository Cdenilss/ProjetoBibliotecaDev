using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjetoBiblioteca.Application.Validators;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddMediatRHandlers()
            .AddFluentValidation();

        return services;
    }

    private static IServiceCollection AddMediatRHandlers(this IServiceCollection services)
    {
        // Registra todos os handlers do assembly atual
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly)
        );

        return services;
    }

    private static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        // Registra todos os validadores do assembly atual
        services.AddValidatorsFromAssemblyContaining<CreateUserValidator>(ServiceLifetime.Scoped);

        // Adiciona o pipeline de validação global
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}