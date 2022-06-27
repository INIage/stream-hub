namespace WebSocket;

using Microsoft.AspNetCore.Http;
using System.Net.WebSockets;
using System.Text.Json.Nodes;
using Utility.Extentions;
using Utility.Option;
using Utility.Serialization;

public sealed class WebSocketAdapter : IWebSocket, IDisposable
{
    private readonly WebSocket websocket;

    private WebSocketAdapter(WebSocket websocket)
    {
        this.websocket = websocket;
    }

    public bool Opened => websocket.State == WebSocketState.Open;

    public static async Task<WebSocketAdapter> Connect(string url)
    {
        var websocket = new ClientWebSocket();
        await websocket.ConnectAsync(new Uri(url), CancellationToken.None);
        return new WebSocketAdapter(websocket);
    }

    internal static async Task<WebSocketAdapter> Connect(HttpContext context)
    {
        var websocket = await context.WebSockets.AcceptWebSocketAsync();
        return new WebSocketAdapter(websocket);
    }

    // for foreign sites
    public async Task Run<T, R>(Func<T, Task<Option<R>>> callback)
    {
        while (Opened)
        {
            var response = await Receive<T>();

            var option = await callback(response);

            await option.Iter(result => Send(result));

            if (websocket.State == WebSocketState.CloseReceived)
            {
                await Close(WebSocketCloseStatus.NormalClosure);
            }
        }
    }

    public Task Run<T, R>(Func<T, Option<R>> callback)
    {
        return Run<T, R>(result => Task.FromResult(callback(result)));
    }

    public async Task Run<T, R>(Func<T, Task<IEnumerable<Option<R>>>> callback)
    {
        while (Opened)
        {
            var response = await Receive<T>();

            var options = await callback(response);

            await options.IterOption(result => Send(result));

            if (websocket.State == WebSocketState.CloseReceived)
            {
                await Close(WebSocketCloseStatus.NormalClosure);
            }
        }
    }

    public Task Run<T, R>(Func<T, IEnumerable<Option<R>>> callback)
    {
        return Run<T, R>(result => Task.FromResult(callback(result)));
    }

    public Task Close(WebSocketCloseStatus status, string? description = null)
    {
        return websocket.CloseAsync(status, description, CancellationToken.None);
    }

    public Task Send<T>(T obj)
    {
        return BaseSendAsync(Json.SerializeToUtf8Bytes(obj));
    }

    public async Task<T> Receive<T>()
    {
        return Json.Deserialize<T>(await BaseReceiveAsync());
    }

    public Task<JsonObject> Receive()
    {
        return Receive<JsonObject>();
    }

    private async Task BaseSendAsync(byte[] bytes)
    {
        if (!Opened)
        {
            return;
        }

        await websocket.SendAsync(bytes, WebSocketMessageType.Text, true, CancellationToken.None);
    }

    private async Task<byte[]> BaseReceiveAsync()
    {
        var buffer = WebSocket.CreateServerBuffer(1024 * 4);
        var bytes = new List<byte>();
        WebSocketReceiveResult result;

        do
        {
            result = await websocket.ReceiveAsync(buffer, CancellationToken.None);

            bytes.AddRange(buffer.Slice(0, result.Count));

        } while (!result.EndOfMessage);

        return bytes.ToArray();
    }

    private async Task<byte[]> BaseReceiveRec()
    {
        var buffer = WebSocket.CreateServerBuffer(1024 * 4);
        var result = await websocket.ReceiveAsync(buffer, CancellationToken.None);
        var bytes = buffer.Slice(0, result.Count).ToArray();

        if (result.EndOfMessage)
        {
            return bytes;
        }
        else
        {
            var result2 = await BaseReceiveRec();
            return bytes.Concat(result2).ToArray();
        }
    }

    public void Dispose()
    {
        websocket?.Dispose();
    }
}

/*
 * 
 * нужно делать обработку сообщений как шину, запускать обработчики (хендлеры) из проектов конкретного сайта
 * и после получения ответа из обработчика отсылать ответ на свой фронт
 * 
 */
