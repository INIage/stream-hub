namespace Chat.Handlers;

using Core.Models;
using Utility.Extentions;
using Utility.Option;
using Utility.Serialization;
using WebSocket;

internal sealed class ConnectHandler : ReplyHandler
{
    private readonly ChatContext context;
    private readonly IEnumerable<IConnecter> connecters;

    public ConnectHandler(ChatContext context, IEnumerable<IConnecter> connecters)
    {
        this.connecters = connecters;
        this.context = context;
    }

    protected override string Type => nameof(Connect);

    public override Option<Reply> Handle(Reply responce)
    {
        var connect = Json.Deserialize<Connect>(responce.data);

        foreach (var connector in connecters)
        {
            context.connections[connector.SiteName] =
                Task.Run(async () =>
                {
                    await connector.Connect(connect.connections[connector.SiteName]);

                    while (context.websocket.Opened)
                    {
                        var options = await connector.Receive();
                        await options.IterOption(result => context.websocket.Send(result));
                    }
                });
        }

        return Option.None<Reply>();
    }
}
