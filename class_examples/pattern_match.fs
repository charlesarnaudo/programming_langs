// let f x y =
//      if y = 0 then x
//      else if x = 0 then y
//      else x / y
let f x y = 
    match (x, y) with
    | (x, 0) -> x
    | (0, y) -> y
    | (_, _) -> x / y

// let f (L : int list) =
//      if L.IsEmpty then []
//      else if L.Tail.IsEmpty then L
//      else [L.Tail.Head]
let f2 (L : int list) =
    match L with 
    | [] -> []
    | h::[] -> L
    | h::t -> [t.Head]

// let rec snoc a (L : 'a list) =
//   if L.IsEmpty then [a]
//   else L.Head::snoc a L.Tail
let rec snoc a (L: 'a list) =
    match L with 
    | [] -> [a]
    | _ -> L.Head::(snoc a L.Tail)

//let rec rac (L : ’a list) =
//    if L.Tail.IsEmpty then L.Head
//    else rac L.Tail
let rec rac (L : 'a list) =
    match L with 
    | h::[] -> h
    | _ -> rac L.Tail

// let rec rdc (L : ’a list) =
//     if L.Tail.IsEmpty then []
//     else L.Head::rdc(L.Tail);;
let rec rdc (L : 'a list) =
    match L with 
    | h::[] -> []
    | _ -> L.Head::(rdc L.Tail)