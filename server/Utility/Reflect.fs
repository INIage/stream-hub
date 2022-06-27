namespace StreamHub.Utility

module Reflect =  
  open System
  open System.Reflection
  
  let assemblies =
    AppDomain.CurrentDomain.GetAssemblies()
    |> Array.toList

  let types =
    assemblies
    |> List.collect (fun assembly -> assembly.GetTypes() |> Array.toList)
      
  let methods =
    types
    |> List.collect (fun typ -> typ.GetMethods() |> Array.toList)

  let hasAttribute<'a when 'a :> Attribute> (provider: ICustomAttributeProvider) =
     provider.IsDefined (typeof<'a>, true)

  let getAttribute<'a when 'a :> Attribute> (provider: ICustomAttributeProvider) =
    provider.GetCustomAttributes true
    |> Array.pick Obj.tryCast<'a>

  let hasInterface<'a> (typ: Type) =
    typ.GetInterfaces()
    |> Array.tryFind (fun i -> i.Name = typeof<'a>.Name)
    |> Option.isSome

  let instance<'a> (typ: Type) =
    typ
    |> Activator.CreateInstance
    :?> 'a
