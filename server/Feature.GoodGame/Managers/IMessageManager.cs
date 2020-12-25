using Feature.GoodGame.Models;

namespace Feature.GoodGame.Managers
{
    internal interface IMessageManager
    {
        Statement Auth(string token, int userId);
        Statement GetChannelHistory();
        Statement GetIgnoreList();
        Statement Join(string channelId);
        Statement Ping();
        Statement Pong();
    }
}