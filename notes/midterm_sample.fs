type irs = I of int | R of double | S of string | IR of int * double | IS of int * string
type 'e mylist = NIL | CONS of 'e * 'e mylist

let count5 L =
    let rec count5helper L n = 
        match L with
        | [] -> 0
        | _ -> if L.Head=5 then (n+1 + count5helper L.Tail 1) else count5helper L.Tail 0
    in
        count5helper L 0

let imult x y =
    match (x, y) with
    | (I a), (I b) -> I (a * b)

let IxS i s =
    match (i, s) with
    | (I i), (S s) -> IS (i, s)    

let myLength (L : 'e mylist) =
    let rec myLengthHelper L n =
        match L with
        | NIL -> 0
        | CONS (h, t) -> myLengthHelper t n+1
    in
        myLengthHelper L 0

let rec rdc (L :'a list) =
    match L with 
    | h::[] -> []
    | h::t -> h::(rdc L.Tail)

let rec tailRdc a (b : 'a list) =
    match b with 
    | [h] -> a
    | h::t ->  tailRdc (h::a) t