namespace Foundation.WebSockets.Server.Middleware
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    using Foundation.Utility.Extentions;

    using Reflection;

    internal class WebSocketServerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IServiceProvider provider;
        private readonly Dictionary<string, Type> sockets;

        public WebSocketServerMiddleware(RequestDelegate next, IServiceProvider provider, Reflect reflect)
        {
            this.next = next;
            this.provider = provider;
            this.sockets = reflect.GetSockets();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                var type = sockets[context.Request.Path];
                if (type is not null)
                {
                    var websocket = await Socket.Connect(context);

                    var instance = type.CreateInstance<ISocket>(provider);
                    await instance.Init(websocket);
                }
            }
            else
            {
                await next(context);
            }
        }
    }
}
