namespace A4

module A4 =
  type 'element mylist = NIL | CONS of 'element * 'element mylist
  type Complexity = NoAns | Constant | Linear | Logarithmic | NLogN | NSquared | NFactorial

  // tail recursive helper func for rev, which takes 'a mylist's
  let rec helper a b =
    match a with 
    | NIL -> b
    | CONS(h, t) ->  helper t (CONS(h, b))
  
  // rev for 'a mylist's
  let rev L = helper L NIL

  // tail recursive helper func for rev2, which takes 'a list's
  let rec helper2 a b =
    match a with 
    | [] -> b
    | h::t ->  helper2 t (h::b)
  
  // rev for 'a list's, needed for vecAddHelper
  let rev2 L = helper2 L []

  // tail recursive vector addition. Made tail recursive by adding a third parameter, out, which stores the results of addition
  // in each iteration
  // once the two lists to be added are empty, reverse out, which is the solution
  let rec vecAddHelper (v1 : int list) (v2 : int list) (out : int list) =
    match (v1, v2) with
    | ([], []) -> rev2 out
    | (h1::t1, h2::t2) -> vecAddHelper t1 t2 ((h1 + h2)::out)
 
 // vecadd takes two lists, and calls vecaddhelper, passing an addition empty list, which stores the result
  let vecadd v1 v2 = vecAddHelper v1 v2 []
  
  let vecaddComplexity = Linear

  // only line that needed to be modified is the third pattern match in the merge sub-func
  // which just calls the passed func f on x and y
  let rec mergeSort f L =
    match L with
     | [] -> []
     | _::[] -> L
     | theList ->
      let rec halve L =
       match L with
        | [] -> ([], [])
        | a::[] -> ([a], [])
        | a::b::cs ->
          let (x, y) = halve cs
          (a::x, b::y)
      let rec merge (L1, L2) =
       match (L1, L2) with
        | ([], ys) -> ys
        | (xs, []) -> xs
        | (x::xs, y::ys) when f x y -> x::merge(xs,y::ys)
        | (x::xs, y::ys) -> y::merge(x::xs,ys)
      let (x, y) = halve theList
      in
      merge (mergeSort f x, mergeSort f y)

  // modified mergeSort to handle myList types, which generally means converting [] to NIL
  // and x::y to CONS (x, y)
  let rec mylistMergeSort f (L : 'a mylist) =
    match L with
     | NIL -> NIL
     | CONS (_, NIL) -> L
     | theList ->
      let rec halve (L : 'a mylist) =
       match L with
        | NIL -> (NIL, NIL)
        | CONS (a, NIL) -> (CONS (a, NIL), NIL)
        | CONS (a, CONS (b, cs))->
          let (x, y) = halve cs
          (CONS (a, x), CONS (b, y))
      let rec merge (L1 : 'a mylist, L2 : 'a mylist) =
       match (L1, L2) with
        | (NIL, ys) -> ys
        | (xs, NIL) -> xs
        | (CONS (x, xs), CONS (y, ys)) when f x y -> CONS (x, merge(xs, CONS (y, ys)))
        | (CONS (x, xs), CONS (y, ys)) -> CONS (y, merge( CONS (x, xs),ys))
      let (x, y) = halve theList
      in
      merge (mylistMergeSort f x, mylistMergeSort f y)
  
  