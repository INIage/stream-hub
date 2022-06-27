namespace StreamHub.Utility

module List =

  let tuple mapping array =
    List.map (fun item -> (item, mapping item)) array
      
  let tuple2 mapping1 mapping2 array =
    List.map (fun item -> (item, mapping1 item, mapping2 item)) array

  let call (argument: 'a) (array: ('a -> unit) list) =
    List.iter (fun item -> item argument) array

  let callMap (argument: 'a) (array: ('a -> 'b) list) =
    List.map (fun item -> item argument) array
