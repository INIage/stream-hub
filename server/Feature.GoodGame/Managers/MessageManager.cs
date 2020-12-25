namespace Feature.GoodGame.Managers
{
    using System.Globalization;

    using Models;

    internal class MessageManager : IMessageManager
    {
        public MessageManager()
        {

        }

        public Statement Statement<T>(T data)
        {
            return new Statement
            {
                data = data,
                type = typeof(T).Name.ToLower(CultureInfo.InvariantCulture),
            };
        }

        public Statement Auth(string token, int userId)
        {
            return new Statement
            {
                data = new Auth
                {
                    token = token,
                    user_id = userId,
                },
                type = Constants.Types.Auth,
            };
        }

        public Statement Join(string channelId)
        {
            return new Statement
            {
                data = new Join
                {
                    channel_id = channelId,
                    hidden = 0,
                },
                type = Constants.Types.Join,
            };
        }

        public Statement GetChannelHistory()
        {
            return new Statement { type = Constants.Types.GetChannelHistory };
        }

        public Statement GetIgnoreList()
        {
            return new Statement { type = Constants.Types.GetIgnoreList };
        }

        public Statement Ping()
        {
            return new Statement { type = Constants.Types.Ping };
        }

        public Statement Pong()
        {
            return new Statement { type = Constants.Types.Pong };
        }
    }
}
