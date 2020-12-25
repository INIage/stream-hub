namespace Foundation.WebSockets
{
    using System;
    using System.Net.WebSockets;
    using System.Threading.Tasks;

    #nullable enable
    public interface IWebSocket
    {
        Task Run<T>(Func<T, Task> callback);

        Task CloseAsync(WebSocketCloseStatus status, string? description = null);

        Task<T> ReceiveAsync<T>();

        Task SendAsync(string response);

        Task SendAsync<T>(T obj);
    }
}
