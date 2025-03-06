using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Auth;
using ProjetoBiblioteca.Infrastructure.Persistence;
using ProjetoBiblioteca.Infrastructure.Persistence.Repositories;

namespace ProjetoBiblioteca.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastrucutre(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories()
            .AddDatabase(configuration)
            .AddAuth(configuration);
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
        services.AddScoped<ILoanRepository, LoanRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthService, AuthServices>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o=>
                    o.TokenValidationParameters= new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                    });
        return services;
    }
}