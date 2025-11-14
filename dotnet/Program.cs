using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.AspNetCore;
using HelloMcpServer.Tools;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddMcpServer()
    .WithHttpTransport((options) =>
    {
        options.Stateless = true;
    })
    .WithTools<HelloTool>();

builder.Logging.AddConsole(options =>
{
    options.LogToStandardErrorThreshold = LogLevel.Error;
});

var app = builder.Build();

// Add health check endpoint
app.MapGet("/api/healthz", () => "Healthy");

// Map MCP endpoints
app.MapMcp(pattern: "/mcp");

await app.RunAsync();