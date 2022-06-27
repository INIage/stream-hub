namespace Site.GoodGame;

using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Site.GoodGame.Handlers;
using WebSocket;

internal sealed class Rejestry : IRejestry
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IReplyHandler, MessageHandler>();
        services.AddScoped<IReplyHandler, SuccessAuthHandler>();
        services.AddScoped<IReplyHandler, SuccessJoinHandler>();
        services.AddScoped<IReplyHandler, WelcomeHandler>();

        services.AddScoped<GoodGameContext>();
        services.AddScoped<IConnecter, GoodGameConnecter>();
    }
}
