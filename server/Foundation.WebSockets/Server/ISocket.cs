namespace Foundation.WebSockets.Server
{
    using System.Threading.Tasks;

    public interface ISocket
    {
        Task Init(IWebSocket websocket);
    }
}
