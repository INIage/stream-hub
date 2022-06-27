namespace StreamHub.WebSocket.Server

open System
open System.Net.WebSockets
open System.Threading.Tasks

open Microsoft.AspNetCore.Http;
open Microsoft.Extensions.DependencyInjection

open StreamHub.Utility

type ISocket =
  abstract member route: string
  abstract member entry: websocket: WebSocket -> Async<unit>

type internal WebSocketServerMiddleware(next: RequestDelegate, provider: IServiceProvider) =
  let sockets =
    Reflect.types
    |> List.filter Reflect.hasInterface<ISocket>
    |> List.map (fun typ -> ActivatorUtilities.CreateInstance (provider, typ) :?> ISocket)

  let Connect (socket: ISocket) (context: HttpContext) =
    async {
      let! websocket = context.WebSockets.AcceptWebSocketAsync() |> Async.AwaitTask
      do! socket.entry websocket
    }

  member this.InvokeAsync (context: HttpContext) =
    if context.WebSockets.IsWebSocketRequest
    then
      async {
        sockets
        |> List.iter (fun socket ->
          if socket.route = context.Request.Path.Value
          then Connect socket context |> Async.StartImmediate
        )
      } |> Async.StartAsTask :> Task
    else next.Invoke context
