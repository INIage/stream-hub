namespace Chat;

using WebSocket;

public sealed class ChatContext
{
    public IWebSocket websocket;
    public IDictionary<string, Task> connections = new Dictionary<string, Task>();
}
