namespace A1

module A1 =
    type Complexity = NoAns | Constant | Linear | Logarithmic | NLogN | NSquared | NFactorial

    // Takes type a' (should be an int) and returns type bigint
    // Recursively calls factorial until input has been completely multiplied (decrements input)
    let rec factorial n:bigint =
        if n <= 0 then bigint 1 else bigint n * factorial (n-1)

    // Returns binomial coeffcient of n k 
    let C n k =
        factorial(n) / (factorial(k) * factorial(n - k)) 

    // The func will be called n! / (n-k)! times, and even if (n - k) = 1, that still means its n! /1 
    // So its complexity will always be at least n factorial
    let CComplexity () = NFactorial

    // Only compares first two elements in both lists
    // If first element is smaller than second element, call biggest with the tail of the list
    // else, append first element of list with the list onwards from the second element
    let rec biggest (L : int list) =
        if L.Length = 1 then L.Head 
        else if L.Head < L.Tail.Head then biggest L.Tail else biggest (L.Head::L.Tail.Tail)

    // if the list is empty, because that is when we are done searching the list
    // If the Head of the list is postive, keep it, and check the rest of the list recursively
    // else, throw the head away (which is negative) and recursively check the rest of the list
    let rec positive (L : int list) =
        if L.IsEmpty then [] 
        else if L.Head >= 0 then L.Head::(positive L.Tail) 
        else positive L.Tail

    let rec isMember a L =
        match L with
        | [] -> false
        | h::t -> if a=h then true else isMember a t

    // if the list is empty, because that is when we are done searching the list
    // If the head of the L1 is a member of L2, keep it and traverse rest of list
    // else toss it and keep searching
    let rec intersect (L1 :int list) (L2 :int list) =
        if L1.IsEmpty then [] 
        else if isMember L1.Head L2 then L1.Head::(intersect L1.Tail L2) 
        else intersect L1.Tail L2

    // If element to be inserted is smaller than the head, than append to the list!
    // else, recursively call insert. This will loop through until inserted element is less than the next 
    // element in the list, and then append to that and then append all the previous heads
    let rec insert (e: int) (L:int list) =
        if L.IsEmpty then e::[] 
        else if e <= L.Head then e::L
        else L.Head::(insert e L.Tail)

    // The complexity grows with the length of List L, where at most it will have O(len(L)) 
    // and at least O(1)
    let insertComplexity () = Linear

    // If list is empty return it ¯\_(ツ)_/¯
    // else, insert the head with the rest of the list onwards sorted
    let rec sort (L:int list) =
        if L.IsEmpty then []
        else insert L.Head (sort L.Tail)

    // It has the same complexity as insertion because all its doing is calling that, at most 2n times
    let sortComplexity () = Linear

    // If the list is empty, we are done adding elements
    // else, Add the head of both lists, and append them to the addition of the rests of the lists,
    // which will add each next index until the end
    let rec vecadd (L1:int list) (L2:int list) = 
        if L1.IsEmpty then []
        else (L1.Head + L2.Head)::vecadd L1.Tail L2.Tail

    // If the list is empty, we are done adding vectors
    // else, add the vectors at the head of both lists, and append to the addition of the rest of lists,
    // using matadd to process those additions
    let rec matadd (L1:list<int list>) (L2:list<int list>) =
        if L1.IsEmpty then []
        else vecadd L1.Head L2.Head::matadd L1.Tail L2.Tail
