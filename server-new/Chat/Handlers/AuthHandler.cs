namespace Chat.Handlers;

using Core.Models;
using Utility.Option;

internal sealed class AuthHandler : ReplyHandler
{
    protected override string Type => nameof(Auth);

    public override Option<Reply> Handle(Reply  responce)
    {
        return Option.None<Reply>();
    }
}
