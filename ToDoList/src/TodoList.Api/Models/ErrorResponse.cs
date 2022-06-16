using System.Net;
using System.Text.Json;

namespace TodoList.Api.Models;


[Obsolete]
public class ErrorResponse
{
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
    public string Message { get; set; } = "An unexpected error occurred.";
    public string ToJsonString() => JsonSerializer.Serialize(this);
}