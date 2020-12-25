namespace Feature.Chat.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Foundation.Connect.Provider;
    using Foundation.Utility.Extentions;
    using Foundation.WebSockets;

    public class ChatService : IChatService
    {
        private readonly IConnectProvider providep;

        public ChatService(IConnectProvider connectProvider)
        {
            this.providep = connectProvider;
        }

        public async Task Join(object data, IWebSocket server)
        {
            var sites = data.Cast<List<(string, object)>>();
            await providep.Connect(sites, server);
        }
    }
}
