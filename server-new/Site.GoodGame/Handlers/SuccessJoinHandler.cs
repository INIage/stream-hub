namespace Site.GoodGame.Handlers;

using Core.Models;
using Site.GoodGame.Constants;
using Site.GoodGame.Models;
using Utility.Option;

internal sealed class SuccessJoinHandler : ReplyHandler
{
    public readonly GoodGameContext context;

    public SuccessJoinHandler(GoodGameContext context)
    {
        this.context = context;
    }

    protected override string Type => Types.SuccessJoin;

    public override Option<Reply> Handle(GoodGameResponce responce)
    {
        context.isJoined = true;

        return Option.None<Reply>();
    }
}
