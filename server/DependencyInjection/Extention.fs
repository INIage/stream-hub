namespace StreamHub.DependencyInjection

open System.Runtime.CompilerServices
open Microsoft.Extensions.DependencyInjection;

[<Extension>]
type DependencyInjectionExtention() =
  [<Extension>]
  static member AddDependencyInjection (service: IServiceCollection) =
    DependencyInjection.ingect service
