namespace StreamHub.WebSocket

open System.Runtime.CompilerServices
open Microsoft.AspNetCore.Builder

open StreamHub.WebSocket.Server;

[<Extension>]
type WebSocketExtention() =
  [<Extension>]
  static member UseWebSocketServer (app: IApplicationBuilder) =
    app.UseMiddleware<WebSocketServerMiddleware> ()
