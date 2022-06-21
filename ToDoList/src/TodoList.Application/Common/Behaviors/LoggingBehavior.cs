using System.Reflection;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger<LoggingBehaviour<TRequest>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest>> logger)
    {
        _logger = logger;
    }
    
    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Handling {typeof(TRequest).Name}");
        
        IList<PropertyInfo> props = new List<PropertyInfo>(request.GetType().GetProperties());
        foreach (var prop in props)
        {
            var propValue = prop.GetValue(request, null);
            _logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
        }
    }
}