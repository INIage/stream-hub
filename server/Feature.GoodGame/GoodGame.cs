namespace Feature.GoodGame
{
    using System.Threading.Tasks;

    using Foundation.Connect.Models;
    using Foundation.WebSockets;

    using Constants;
    using Managers;
    using Services;

    internal class GoodGame
    {
        private readonly IMessageManager message;
        private readonly IGoodGameService service;
        private IWebSocket websocket;

        public GoodGame(IMessageManager messageManager, IGoodGameService goodgameService)
        {
            this.message = messageManager;
            this.service = goodgameService;
        }

        public async Task Run(IWebSocket websocket, IWebSocket server)
        {
            service.Init(server);
            
            await websocket.Run(async (Statement statement) =>
            {
                switch (statement.type)
                {
                    case Types.Message:
                        await service.Message(statement.data);
                        break;
                    default:
                        //await manager.SendAsync(response);
                        break;
                }
            });
        }
    }
}
