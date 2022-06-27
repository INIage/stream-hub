namespace Site.GoodGame.Handlers;

using Core.Models;
using Site.GoodGame.Constants;
using Site.GoodGame.Models;
using Utility.Option;

internal sealed class SuccessAuthHandler : ReplyHandler
{
    public readonly GoodGameContext context;

    public SuccessAuthHandler(GoodGameContext context)
    {
        this.context = context;
    }

    protected override string Type => Types.SuccessAuth;

    public override Option<Reply> Handle(GoodGameResponce responce)
    {
        var join = new Join
        {
            channel_id = context.user.channel.id,
            hidden = 0,
        };

        var request = new GoodGameRequest<Join>
        {
            data = join,
            type = Types.Join,
        };

        context.websocket.Send(request);

        return Option.None<Reply>();
    }
}
