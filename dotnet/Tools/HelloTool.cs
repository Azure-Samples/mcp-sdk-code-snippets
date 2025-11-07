using ModelContextProtocol;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace HelloMcpServer.Tools;

[McpServerToolType]
public sealed class HelloTool
{
    [McpServerTool, Description("Returns a friendly hello message for a given name.")]
    public static HelloResponse SayHello(HelloRequest request)
    {
        return new HelloResponse
        {
            Message = $"Hello, {request.Name}!"
        };
    }
}

public class HelloRequest
{
    public string Name { get; set; } = "";
}

public class HelloResponse
{
    public string Message { get; set; } = "";
}