namespace Site.GoodGame.Handlers;

using Core.Models;
using Models;
using Utility.Option;

internal interface IReplyHandler
{
    bool Match(GoodGameResponce responce);
    Option<Reply> Handle(GoodGameResponce responce);
}
