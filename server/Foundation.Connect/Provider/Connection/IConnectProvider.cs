namespace Foundation.Connect.Provider
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Foundation.WebSockets;

    public interface IConnectProvider
    {
        Task Connect(List<(string, object)> sites, IWebSocket server);
    }
}
