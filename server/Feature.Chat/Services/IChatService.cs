namespace Feature.Chat.Services
{
    using System.Threading.Tasks;

    using Foundation.WebSockets;

    public interface IChatService
    {
        Task Join(object data, IWebSocket server);
    }
}
