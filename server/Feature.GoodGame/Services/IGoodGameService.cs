using Foundation.WebSockets;
using System.Threading.Tasks;

namespace Feature.GoodGame.Services
{
    internal interface IGoodGameService
    {
        void Init(IWebSocket server);
        Task Message(object data);
    }
}