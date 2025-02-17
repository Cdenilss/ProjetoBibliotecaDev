using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Persistence;
using ProjetoBiblioteca.Infrastructure.Persistence.Repositories;

namespace ProjetoBiblioteca.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastrucutre(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories()
            .AddDatabase(configuration);
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        
        var connectionString = configuration.GetConnectionString("BibliotecaDevCs");
        services.AddDbContext<LibraryDbContext>(o => o.UseSqlServer(connectionString));
        return services;
        
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {

        services.AddScoped<IBookRepository, BookRepository>();
        
        return services;
    }
}