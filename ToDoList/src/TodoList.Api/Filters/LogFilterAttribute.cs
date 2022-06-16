using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TodoList.Api.Filters;

public class LogFilterAttribute : IActionFilter
{
    private readonly ILogger<LogFilterAttribute> _logger;

    public LogFilterAttribute(ILogger<LogFilterAttribute> logger) => _logger = logger;

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];
        
        var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("Command")).Value;

        _logger.LogInformation($"Controller:{controller}, action: {action}, Incoming request: {JsonSerializer.Serialize(param)}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];
        
        var result = (ObjectResult)context.Result!;

        _logger.LogInformation($"Controller:{controller}, action: {action}, Executing response: {JsonSerializer.Serialize(result.Value)}");
    }
}