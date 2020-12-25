namespace Feature.Chat.Managers
{
    using Foundation.Connect.Models;
    
    using Constants;

    internal class MessageManager : IMessageManager
    {
        public Statement Message(string nickName, string text)
        {
            return new Statement
            {
                data = new Message
                {
                    nickName = nickName,
                    text = text,
                },
                type = Types.Message,
            };
        }

        public Statement Welcome()
        {
            return new Statement { type = Types.Welcome };
        }
    }
}
