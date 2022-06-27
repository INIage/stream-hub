namespace Chat.Handlers;

using Core.Models;
using Utility.Option;

internal abstract class ReplyHandler : IReplyHandler
{
    protected abstract string Type { get; }

    public bool Match(Reply reply) => reply.type == Type;

    public abstract Option<Reply> Handle(Reply reply);
}
