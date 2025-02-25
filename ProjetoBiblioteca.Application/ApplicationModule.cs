using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjetoBiblioteca.Application.Commands.BookCommands.InsertBook;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Application.Validators;

namespace ProjetoBiblioteca.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddHandlers()
            .AddValidation();
        return services;
    }
    
    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertBookCommand>()
        );
        services.AddTransient<IPipelineBehavior<InsertBookCommand, ResultViewModel<int>>,
            ValidateInsertBookCommandBehavior>();
        return services;
    }

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining<InsertBookCommand>();
        return services;
    }
}