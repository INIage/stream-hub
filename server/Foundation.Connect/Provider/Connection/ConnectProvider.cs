namespace Foundation.Connect.Provider
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Foundation.WebSockets;

    using Reflection;

    internal class ConnectProvider : IConnectProvider
    {
        private readonly Dictionary<string, IConnecter> cients;

        public ConnectProvider(Reflect reflect)
        {
            cients = reflect.GetClients();
        }

        public async Task Connect(List<(string, object)> sites, IWebSocket server)
        {
            var tasks = new List<Task>();

            foreach (var (site, data) in sites)
            {
                tasks.Add(cients[site].Connect(data, server));
            }

            await Task.WhenAll(tasks);
        }
    }
}
