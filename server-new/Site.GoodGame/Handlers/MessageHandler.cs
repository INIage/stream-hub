using Core.Models;
using Site.GoodGame.Constants;
using Utility.Option;
using Utility.Serialization;

namespace Site.GoodGame.Handlers;

internal sealed class MessageHandler : ReplyHandler
{
    protected override string Type => Types.Message;

    public override Option<Reply> Handle(Models.GoodGameResponce responce)
    {      
        var message = Json.Deserialize<Models.Message>(responce.data);
      
        var result = Reply.New(
            new Message
            {      
                NickName = message.user_name,      
                Text= message.text,      
            }
        );
      
        return Option.Some(result);
    }
}
