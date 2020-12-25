namespace Feature.GoodGame
{
    using System.Threading.Tasks;

    using Foundation.Connect;
    using Foundation.WebSockets;
    using Foundation.Utility.Extentions;

    using Constants;
    using Managers;
    using Models;

    [SiteName("GoodGame")]
    internal class Connecter : IConnecter
    {
        private const string url = "wss://chat-1.goodgame.ru/chat2/";

        private readonly GoodGame goodgame;
        private readonly IMessageManager message;

        public Connecter(GoodGame goodgame, IMessageManager messageManager)
        {
            this.goodgame = goodgame;
            this.message = messageManager;
        }

        public async Task Connect(object value, IWebSocket server)
        {
            var user = value.Cast<User>();

            var websocket = await Socket.Connect(url);

            var isAuth = false;

            while (!isAuth)
            {
                var responce = await websocket.ReceiveAsync<Statement>();
                switch (responce.type)
                {
                    case Types.Welcome:
                        await websocket.SendAsync(message.Auth(user.token, user.id));
                        break;
                    case Types.SuccessAuth:
                        await websocket.SendAsync(message.Join(user.channel.id));
                        break;
                    case Types.SuccessJoin:
                        isAuth = true;
                        break;
                    default:
                        break;
                }
            }

            await goodgame.Run(websocket, server);
        }
    }
}
