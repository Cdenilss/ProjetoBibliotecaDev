using FluentValidation;
using MediatR;

namespace ProjetoBiblioteca.Application.Validators;

public class ValidationBehavior<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResultViewModelBase
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        
        if (!_validators.Any())
            return await next();

        
        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(request, cancellationToken))
        );
        
        var failures = validationResults
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();
      
        if (failures.Any())
        {
            var errorMessages = failures.Select(f => f.ErrorMessage).ToArray();

            
            var errorResponse = Activator.CreateInstance(
                typeof(TResponse), 
                false, 
                errorMessages
            ) as TResponse;

            return errorResponse!;
        }

        return await next();
    }
}