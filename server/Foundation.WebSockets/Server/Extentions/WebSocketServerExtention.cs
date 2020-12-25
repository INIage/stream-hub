namespace Foundation.WebSockets.Server
{
    using Microsoft.AspNetCore.Builder;

    using Middleware;

    public static class WebSocketServerExtention
    {

        public static IApplicationBuilder UseSocketServer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebSocketServerMiddleware>();
        }
    }
}
