namespace Site.GoodGame.Handlers;

using Core.Models;
using Models;
using Utility.Option;

internal abstract class ReplyHandler : IReplyHandler
{
    protected abstract string Type { get; }

    public bool Match(GoodGameResponce responce) => responce.type == Type;

    public abstract Option<Reply> Handle(GoodGameResponce responce);
}
