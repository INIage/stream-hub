namespace Chat;

using Chat.Handlers;
using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

internal sealed class Rejestry : IRejestry
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<ChatContext>();

        services.AddScoped<IReplyHandler, AuthHandler>();
        services.AddScoped<IReplyHandler, ConnectHandler>();
    }
}
