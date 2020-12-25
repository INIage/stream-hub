namespace Feature.Chat.Websockets
{
    using System.Threading.Tasks;

    using Foundation.Connect.Models;
    using Foundation.WebSockets;
    using Foundation.WebSockets.Server;

    using Constants;
    using Managers;
    using Services;

    [Socket("/chat")]
    internal class ChatWebSocket : ISocket
    {
        private readonly IChatService service;
        private readonly IMessageManager message;

        public ChatWebSocket(IChatService chatService, IMessageManager messageManager)
        {
            this.service = chatService;
            this.message = messageManager;
        }

        public async Task Init(IWebSocket websocket)
        {
            await websocket.SendAsync(message.Welcome());

            await websocket.Run(async (Statement statement) =>
            {
                switch (statement.type)
                {
                    case Types.Join:
                        await service.Join(statement.data, websocket);
                        break;
                    default:
                        break;
                }
            });
        }
    }
}
