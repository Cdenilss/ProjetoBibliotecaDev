using MediatR;
using Microsoft.Extensions.Caching.Memory;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Auth;

namespace ProjetoBiblioteca.Application.Commands.UserCommands.PutPasswordRecovery;

public class PasswordRecoveryChangeCommandHandler : IRequestHandler<PasswordRecoveryChangeCommand, ResultViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly IMemoryCache _cache;

    public PasswordRecoveryChangeCommandHandler(IUserRepository userRepository, IAuthService authService, IMemoryCache cache)
    {
        _userRepository = userRepository;
        _authService = authService;
        _cache = cache;
    }

    public async Task<ResultViewModel> Handle(PasswordRecoveryChangeCommand request, CancellationToken cancellationToken)
    {
        var cacheKey = $"Recovery Code :{request.Email}";

        if (!_cache.TryGetValue(cacheKey, out string? code) || code != request.Code)
        {
            return ResultViewModel<string>.Error("Código inválido");
        }
        
        var user = await _userRepository.GetByEmail(request.Email);

        if (user == null)
        {
            return ResultViewModel<string>.Error("Usuário não encontrado");
        }
      
        var hash = _authService.ComputeHash(request.NewPassword);
        await _userRepository.UpdatePassword(user,hash);
        
        _cache.Remove(cacheKey);

        return ResultViewModel.Sucess();

    }
}