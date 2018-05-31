namespace LAB3

module LAB3 =
    type SET =
       | I of int list                                  // I [1;2;3]
       | S of string list                               // S ["a";"b";"c"]
       | IS of (int * string) list                      // IS [(1, "a");(2, "b")]
       | II of (int * int) list                         // II [(1,2); (3,4); (5,6)]
       | SS of (string * string) list                   // SS [("a","b"); ("c","d")]
       | SI of (string * int) list                      // SI [("a", 1); ("b", 2); ("c", 3)]
       | SISI of ((string * int) * (string * int)) list // SISI [(("a", 1), ("b", 2)); (("c", 3), "d", 4))]
       | SIIS of ((string * int) * (int * string)) list // SIIS [(("a", 1), (2, "b")); (("c", 3), (4, "d"))]

    // Takes a single element a and a List L
    // Returns the tuple a, and the head of the list and appends its to the next element of the list
    // achieved using recursion
    let rec dist a L = 
      match L with
      | [] -> []
      | _ -> (a, L.Head)::(dist a L.Tail)
      
    // Pairs generates the cartesian product
    // Takes two sets
    // Distributes the first element of l1 one across l2 and appends it
    // to the resulting list from calling pairs on the tail of l1
    let rec pairs s1 s2 = 
      match s1 with
      | [] -> []
      | _ -> (dist s1.Head s2)@(pairs s1.Tail s2)

    // Matching product types
    let product s1 s2 =
      match (s1, s2) with
        | (I s1, I s2) -> II (pairs s1 s2)
        | (S s1, S s2) -> SS (pairs s1 s2)
        | (I s1, S s2) -> IS (pairs s1 s2)
        | (S s1, I s2) -> SI (pairs s1 s2)
        | (SI s1, IS s2) -> SIIS (pairs s1 s2)
        | (SI s1, SI s2) -> SISI (pairs s1 s2)
