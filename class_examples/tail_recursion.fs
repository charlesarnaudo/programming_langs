let rec sum n L =
    match L with 
    | [] -> n
    | _ -> sum (n + L.Head) L.Tail

let rec rdc n L =
    match L with 
    | [] -> n
    | _ -> rdc (L.Head::n) L.Tail