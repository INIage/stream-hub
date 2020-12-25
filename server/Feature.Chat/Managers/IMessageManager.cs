namespace Feature.Chat.Managers
{
    using Foundation.Connect.Models;

    internal interface IMessageManager
    {
        Statement Message(string userName, string text);
        Statement Welcome();
    }
}
