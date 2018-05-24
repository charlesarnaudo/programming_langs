namespace LAB2

module LAB2 =    
    // Note: you need to change this function signature to use patterns
    // Takes two tuples and returns them added
    // If either the first or second tuple (but not both) are a pair of 0s, return other tuple
    // otherwise, return tuples added
    let addTuples ((a, b): int * int) ((c, d): int * int) =
        match ((a, b), (c, d)) with
        | ((0, 0), _) -> (c, d)
        | (_, (0, 0)) -> (a, b)
        | (_, _) -> (a+c, b+d)
    
    // Takes a Function f and paramter x for that func
    // Calls f twice
    let dup f x =
        f (f x)
    