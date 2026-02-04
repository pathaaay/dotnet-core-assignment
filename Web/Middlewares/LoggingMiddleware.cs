using System.Text;

namespace InventoryManager.Web;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine("***Incoming Request***");
        Console.WriteLine($"HTTP - {context.Request.Method} - {context.Request.Path}");
        Console.WriteLine($"Time: {DateTime.Now}");

        await _next(context);

        Console.WriteLine("***Outgoing Response***");
        Console.WriteLine($"Status code {context.Response.StatusCode}");
        Console.WriteLine($"Time: {DateTime.Now}");
    }
}
