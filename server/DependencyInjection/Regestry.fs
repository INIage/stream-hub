namespace StreamHub.DependencyInjection

open Microsoft.Extensions.DependencyInjection;

type IRegestry =
  abstract ConfigureServices: services: IServiceCollection -> unit

(*
type Regestry () =
  interface IRegestry with
    member this.ConfigureServices (services: IServiceCollection) =
      services
        .AddTransient<IRegestry, Regestry>()
      |> ignore
  end
*)
