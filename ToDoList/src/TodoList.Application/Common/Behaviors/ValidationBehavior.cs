using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ValidationException = TodoList.Application.Common.Exceptions.ValidationException;

namespace TodoList.Application.Common.Behaviors;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators) 
        => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();

            if (failures.Any())
                throw new ValidationException(GetValidationErrorMessage(failures));
        }
        return await next();
    }

    private string GetValidationErrorMessage(IEnumerable<ValidationFailure> failures)
    {
        var failureDict = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        
        return string.Join(";", failureDict.Select(kv => kv.Key + ": " + string.Join(' ', kv.Value.ToArray())));
    }
}