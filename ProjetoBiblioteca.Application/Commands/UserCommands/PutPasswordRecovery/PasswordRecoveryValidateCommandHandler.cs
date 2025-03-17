using MediatR;
using Microsoft.Extensions.Caching.Memory;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Auth;

namespace ProjetoBiblioteca.Application.Commands.UserCommands.PutPasswordRecovery;

public class  PasswordRecoveryValidateCommandHandler : IRequestHandler<PasswordRecoveryValidateCommand, ResultViewModel>
{
    private readonly IAuthService _authService;
    private readonly IMemoryCache _cache;

    public PasswordRecoveryValidateCommandHandler(IUserRepository userRepository, IAuthService authService, IMemoryCache cache)
    {
        _authService = authService;
        _cache = cache;
    }

    public async Task<ResultViewModel> Handle(PasswordRecoveryValidateCommand request, CancellationToken cancellationToken)
    {
        var cacheKey = $"Recovery Code :{request.Email}";

        if (!_cache.TryGetValue(cacheKey, out string? code) || code != request.Code)
        {
            return ResultViewModel.Error("Código inválido");
        }
        
        return ResultViewModel.Success();

    }
}