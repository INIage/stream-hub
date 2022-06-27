namespace WebSocket.Controllers;

using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utility.Option;

public abstract class WebSocketController : ControllerBase
{
    [HttpGet]
    public virtual async Task Socket()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var websocket = await WebSocketAdapter.Connect(HttpContext);
            Init(websocket);

            await websocket.Run<Reply, Reply>(Execute);
        }
    }

    protected virtual void Init(IWebSocket websocket) { }

    protected abstract IEnumerable<Option<Reply>> Execute(Reply request);
}
