using MediatR;
using Microsoft.Extensions.Caching.Memory;
using ProjetoBiblioteca.Application.Models.ViewModel;
using ProjetoBiblioteca.Core.Repositories;
using ProjetoBiblioteca.Infrastructure.Auth;
using ProjetoBiblioteca.Infrastructure.Notification;

namespace ProjetoBiblioteca.Application.Commands.UserCommands.PutPasswordRecovery;

public class PasswordRecoveryRequestCommandHandler : IRequestHandler<PasswordRecoveryRequestCommand, ResultViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailServices _emailService;
    private readonly IMemoryCache _cache;

    public PasswordRecoveryRequestCommandHandler(IUserRepository userRepository, IAuthService authService, IEmailServices emailService, IMemoryCache cache)
    {
        _userRepository = userRepository;
        _emailService = emailService;
        _cache = cache;
    }

    public async Task<ResultViewModel> Handle(PasswordRecoveryRequestCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(request.Email);

        if (user == null)
        {
            return ResultViewModel.Error("Usuário não encontrado");
        }

        var code = new Random().Next(100000, 999999).ToString();
        var cachkey = $"Recovery Code :{request.Email}";
        _cache.Set(cachkey,code, TimeSpan.FromMinutes(10));   

        await _emailService.SendAsync(user.Email, "Recuperação de senha", $"Seu código de recuperação é: {code}");

        return ResultViewModel.Success();
    }
}