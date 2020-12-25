namespace Foundation.WebSockets
{
    using System;
    using System.Collections.Generic;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    using Foundation.Utility.Json;

    public static class Socket
    {
        public static async Task<IWebSocket> Connect(string url)
        {
            var websocket = new ClientWebSocket();
            await websocket.ConnectAsync(new Uri(url), CancellationToken.None);
            return new Adapter(websocket);
        }

        public static async Task<IWebSocket> Connect(HttpContext context)
        {
            var websocket = await context.WebSockets.AcceptWebSocketAsync();
            return new Adapter(websocket);
        }

        private class Adapter: IWebSocket
        {
            private readonly WebSocket websocket;

            public Adapter(WebSocket websocket)
            {
                this.websocket = websocket;
            }

            public async Task Run<T>(Func<T, Task> callback)
            {
                while (websocket.State == WebSocketState.Open)
                {
                    var response = await ReceiveAsync<T>();

                    await callback(response);

                    if (websocket.State == WebSocketState.CloseReceived)
                    {
                        await CloseAsync(WebSocketCloseStatus.NormalClosure);
                    }
                }
            }

            public Task CloseAsync(WebSocketCloseStatus status, string description = null)
            {
                return websocket.CloseAsync(status, description, CancellationToken.None);
            }

            public Task SendAsync(string text)
            {
                return BaseSendAsync(Encoding.UTF8.GetBytes(text));
            }

            public Task SendAsync<T>(T obj)
            {
                return BaseSendAsync(Json.Serialize(obj));
            }

            public async Task<T> ReceiveAsync<T>()
            {
                return Json.Deserialize<T>(await BaseReceiveAsync());
            }

            private async Task BaseSendAsync(byte[] bytes)
            {
                if (websocket.State == WebSocketState.Open)
                {
                    await websocket.SendAsync(bytes, WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }

            private async Task<byte[]> BaseReceiveAsync()
            {
                var buffer = WebSocket.CreateServerBuffer(1024 *2);
                var bytes = new List<byte>();
                WebSocketReceiveResult result;

                do
                {
                    result = await websocket.ReceiveAsync(buffer, CancellationToken.None);

                    bytes.AddRange(buffer.Slice(0, result.Count));

                } while (!result.EndOfMessage);

                return bytes.ToArray();
            }
        }
    }
}
