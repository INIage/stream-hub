namespace WebSocket;

using System;
using System.Net.WebSockets;
using System.Text.Json.Nodes;
using Utility.Option;

public interface IWebSocket
{
    bool Opened { get; }
    Task Close(WebSocketCloseStatus status, string? description = null);
    Task<JsonObject> Receive();
    Task<T> Receive<T>();
    Task Run<T, R>(Func<T, Task<Option<R>>> callback);
    Task Run<T, R>(Func<T, Option<R>> callback);
    Task Send<T>(T obj);
}
