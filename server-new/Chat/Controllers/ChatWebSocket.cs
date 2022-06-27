namespace Chat.Controllers;

using Chat.Handlers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Utility.Extentions;
using Utility.Option;
using WebSocket;
using WebSocket.Controllers;

/*
const webSocket = new WebSocket('wss://localhost:7019/chat');
webSocket.onmessage = (message) => console.log(message.data);
webSocket.send('{ "type": "Auth" }');
webSocket.send('{ "type": "Connect" }');
*/

[Route("/chat")]
public sealed class ChatWebSocket : WebSocketController
{
    private readonly ChatContext context;
    private readonly IEnumerable<IReplyHandler> handlers;

    public ChatWebSocket(ChatContext context, IEnumerable<IReplyHandler> handlers)
    {
        this.context = context;
        this.handlers = handlers;
    }

    protected override void Init(IWebSocket websocket)
    {
        context.websocket = websocket;
    }

    protected override IEnumerable<Option<Reply>> Execute(Reply reply)
    {
        return handlers
            .Filter(handler => handler.Match(reply))
            .Map(handler => handler.Handle(reply));
    }
}
