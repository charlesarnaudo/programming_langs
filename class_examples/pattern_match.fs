// Non pattern matched
// let f x y =
//      if y = 0 then x
//      else if x = 0 then y
//      else x / y;;
let f x y = 
    match (x, y) with
    | (x, 0) -> x
    | (0, y) -> y
    | (_, _) -> x / y

// Non pattern matched
// let f (L : int list) =
//      if L.IsEmpty then []
//      else if L.Tail.IsEmpty then L
//      else [L.Tail.Head]
let f2 (L : int list) =
    match L with 
    | [] -> []
    | h::[] -> L
    | h::t -> [t.Head]