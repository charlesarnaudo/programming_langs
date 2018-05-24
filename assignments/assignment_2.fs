namespace A2

module A2 =
    type Complexity = NoAns | Constant | Linear | Logarithmic | NLogN | NSquared | NFactorial
    
    // third returns three lists from a list
    // first three lines are pretty simple, checking for empty lists.
    // the last match statement is the magic.
    // it matches any list with a min 4 elements and saves three vars (x, y, z) from
    // a call to third on the last element d, which we know will be a list.
    // once those calls are done, it appends the found elements to the first three elements of the list
    let rec third L =
        match L with 
        | [] -> ([], [], [])
        | h::[] -> ([h], [], [])
        | a::b::[] -> ([a], [b], [])
        | a::b::c::d ->
          let (x, y, z) = third d
          in
          (a::x, b::y, c::z)

    // Using let saves some time on our part, because we are able to save results without tossing them
    // The complexity is always going to be a factor of the length of the list
    let thirdComplexity = Constant

    // comp calls a function f2 on the result of function f1. Don't get the name but ¯\_(ツ)_/¯
    let comp f1 f2 x = 
        f2 (f1 x)
    
    // returns square of x
    let sq x = x * x

    // magic. Actually just runs through a list and performs given func f on L
    let rec map f L =
        match L with
        | [] -> []
        | h::t -> f h::map f t

    // squares all elements in list. uses map to traverse
    let sqlist L = 
        match L with
        | [] -> []
        | _ -> map sq L

    // depends on size of list, but still just looping through it
    let sqlistComplexity = Constant

    // 2 + 2 = 5 :-)
    let add x y = x + y

    // a variant of the map func
    // loops through two lists 
    let rec map2 f L1 L2 =
       match (L1,L2) with
       | ([], []) -> []
       | (L1, []) -> L1
       | ([], L2) -> L2
       | (h1::t1, h2::t2) -> f h1 h2::map2 f t1 t2

    // apps vectors l1 l2
    let vecadd L1 L2 =
        match (L1, L2) with
        | ([], []) -> []
        | (_, _) -> map2 add L1 L2

    // adds vectors in matrices l1, l2
    let matadd L1 L2 = 
        map2 vecadd L1 L2

    // combines all values in list to a single value using given func f and modifier a
    let rec reduce f a L =
        match L with
        | [] -> a
        | h::t -> f h (reduce f a t)

    // multiplication! 
    let mul (x:int) (y:int) = x * y

    // combines both lists using map2 multiply, which multiplies the values of l1, l2 together
    // then call reduce on that returned list, using the add function, which will add the products together
    let ip L1 L2 = 
        reduce add 0 (map2 mul L1 L2)
