namespace Site.GoodGame;

using Constants;
using Core.Models;
using Microsoft.Extensions.Logging;
using Site.GoodGame.Handlers;
using Site.GoodGame.Models;
using System.Text.Json.Nodes;
using Utility.Extentions;
using Utility.Option;
using Utility.Serialization;
using WebSocket;

internal sealed class GoodGameConnecter : IConnecter
{
    private readonly GoodGameContext context;
    private readonly IEnumerable<IReplyHandler> handlers;
    private readonly ILogger<GoodGameConnecter> logger;

    public GoodGameConnecter(GoodGameContext context, IEnumerable<IReplyHandler> handlers, ILogger<GoodGameConnecter> logger)
    {
        this.context = context;
        this.handlers = handlers;
        this.logger = logger;
    }

    public string SiteName => Setting.name;

    public async Task Connect(JsonNode data)
    {
        context.user = Json.Deserialize<User>(data);
        context.websocket = await WebSocketAdapter.Connect(Setting.url);
    }

    public async Task<IEnumerable<Option<Reply>>> Receive()
    {
        var response = await context.websocket.Receive<GoodGameResponce>();
        logger.LogInformation($"ressived message type: \"{response.type}\"");

        return handlers
            .Filter(handler => handler.Match(response))
            .Map(handler => handler.Handle(response));
    }
}
