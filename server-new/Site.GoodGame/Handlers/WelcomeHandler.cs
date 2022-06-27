namespace Site.GoodGame.Handlers;

using Core.Models;
using Site.GoodGame.Constants;
using Site.GoodGame.Models;
using Utility.Option;

internal sealed class WelcomeHandler : ReplyHandler
{
    private readonly GoodGameContext context;

    public WelcomeHandler(GoodGameContext context)
    {
        this.context = context;
    }

    protected override string Type => Types.Welcome;

    public override Option<Reply> Handle(GoodGameResponce responce)
    {
        var auth = new Models.Auth
        {
            token = context.user.token,
            user_id = context.user.id,
        };

        var request = new GoodGameRequest<Models.Auth>
        {
            data = auth,
            type = Types.Auth,
        };

        context.websocket.Send(request);

        return Option.None<Reply>();
    }
}
