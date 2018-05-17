namespace LAB1

module LAB1 =

    let hello name =
        printfn "Hello %s" name

    // Takes types a' b' 
    // Recursively calls GCD until the lcd is 0, and then returns
    let rec GCD x y =
        if y = 0 then x else GCD y (x%y)

    // Takes type a' (should be an int) and returns type bigint
    // Recursively calls factorial until input has been completely multiplied (decrements input)
    let rec factorial n:bigint =
        if n <= 0 then bigint 1 else bigint n * factorial (n-1)

