namespace StreamHub.DependencyInjection

module DependencyInjection =
  open Microsoft.Extensions.DependencyInjection;

  open StreamHub.Utility

  let registries =
    Reflect.types
    |> List.filter Reflect.hasInterface<IRegestry>
    |> List.map Reflect.instance<IRegestry>

  let ingect (service: IServiceCollection) =
    registries
    |> List.iter (fun regestry -> regestry.ConfigureServices service)
