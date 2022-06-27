namespace StreamHub.WebSocket.Server

// https://github.com/fsprojects/FSharp.Data.GraphQL/blob/dev/samples/star-wars-api/WebSocketMiddleware.fs

module WebSocket =
  open System
  open System.Net.WebSockets
  open System.Text
  open System.Threading
  
  open FSharp.Json

  let private base_send (websocket: WebSocket) (bytes: byte array) =
    async {
      if websocket.State = WebSocketState.Open
      then 
        do! websocket.SendAsync(bytes |> ArraySegment, WebSocketMessageType.Text, true, CancellationToken.None) |> Async.AwaitTask
    }

  let rec private base_receive (websocket: WebSocket) =
    async {
      let buffer = (1024 * 4) |> Array.zeroCreate<byte> |> ArraySegment
      let! received = websocket.ReceiveAsync (buffer, CancellationToken.None) |> Async.AwaitTask
      let bytes = Array.take received.Count buffer.Array
      
      if received.EndOfMessage
      then
        return bytes
      else
        let! result = base_receive websocket
        return Array.append bytes result
    }

  let send (websocket: WebSocket) (obj: 'a) =
    async {
      do! obj
        |> Json.serialize
        |> Encoding.UTF8.GetBytes
        |> base_send websocket
    }

  let receive<'a> (websocket: WebSocket) =
    async {
      let! result = base_receive websocket
      return result
      |> Encoding.UTF8.GetString
      |> Json.deserialize<'a>
    }
    