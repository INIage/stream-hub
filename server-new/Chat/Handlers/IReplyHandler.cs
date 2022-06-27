namespace Chat.Handlers;

using Core.Models;
using Utility.Option;

public interface IReplyHandler
{
    bool Match(Reply responce);
    Option<Reply> Handle(Reply responce);
}
