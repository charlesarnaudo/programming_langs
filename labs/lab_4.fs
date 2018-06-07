namespace LAB4

module LAB4 =
    
    // what the frick?
    // our function adds 1 to a number in the list, and then squares that number
    // Starting at 0 allows us to have all odd numbers, because our list starts at 0 and adds 2 each time
    // for whatever reason, there are numTerms odd numbers between 1 and (numTerms - 1) * 2,
    // so that allows us to square numTerms number of odd numbers
    let oddSquares numTerms = 
        List.map (fun f -> double ((f+1)*(f+1))) [0 .. 2 .. (((numTerms - 1) * 2))]
    
    // define the function using a List.foldBack call
    // followed the pattern from the lab
    let piApprox numTerms =
        -3.0 + (List.foldBack (fun a b -> 6.0 + a / b) (oddSquares numTerms) 1.0)
       
    // define the function using a List.foldBack call
    // followed pattern from lab
    let eApprox numTerms =
        2.0 + (1.0 / (List.foldBack (fun a b -> a + a / b) [1.0..double numTerms] 1.0))
