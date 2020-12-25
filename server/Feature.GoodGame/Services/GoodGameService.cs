namespace Feature.GoodGame.Services
{
    using System.Threading.Tasks;

    using Foundation.Connect.Managers;
    using Foundation.Utility.Extentions;
    using Foundation.WebSockets;

    using Mapper;
    using Models;

    internal class GoodGameService : IGoodGameService
    {
        private readonly IMessageManager manager;
        private readonly IGoodGameMapper mapper;
        private IWebSocket server;

        public GoodGameService(IMessageManager messageManager, IGoodGameMapper goodgameMapper)
        {
            this.manager = messageManager;
            this.mapper = goodgameMapper;
            this.server = null;
        }

        public void Init(IWebSocket server)
        {
            this.server = server;
        }

        public async Task Message(object data)
        {
            var message = mapper.Map(data.Cast<Message>());
            await server?.SendAsync(manager.Statement(message));
        }
    }
}
