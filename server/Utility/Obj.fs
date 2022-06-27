namespace StreamHub.Utility

module Obj =

  let cast<'a> (obj: obj) =
    obj :?> 'a

  let tryCast<'a> (obj: obj) =
    match obj with
    | :? 'a as a -> Some a
    | _ -> None
