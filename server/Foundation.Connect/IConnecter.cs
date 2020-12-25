namespace Foundation.Connect
{
    using System.Threading.Tasks;

    using Foundation.WebSockets;

    public interface IConnecter
    {
        Task Connect(object value, IWebSocket server);
    }
}
