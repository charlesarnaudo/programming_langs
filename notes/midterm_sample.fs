type irs = I of int | R of double | S of string | IR of int * double | IS of int * string


            
let count5 L =
    let rec count5helper L n = 
        match L with
        | [] -> 0
        | _ -> if L.Head=5 then (n+1 + count5helper L.Tail 1) else count5helper L.Tail 0
    in
        count5helper L 0

let lmult x y =
    match (x, y) with
    | (I a), (I b) -> I (a * b)