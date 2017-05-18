open System

/// PART I

module Printing = 
    // Print Hello world.
    printfn "Hello World"

    // Print some integer.
    printfn "This is very C like. This is a number: %d" 123

module Integers = 
    // Basic binding
    let foo = 176

    // Mutable bindnig
    let mutable x = 10
    x <- 20

    // Arithmetic operations
    let bar = (foo / 4 + 5 - 7) * 4
    let barfloat = (float foo / 4. + 5. - 7.) * 4.

    // List of numbers
    let sampleNumbers = [ 0 .. 99 ]

module Tuples = 

    // A simple tuple of integers
    let tuple1 = (1, 2, 3)

    // A tuple consisting of an integer, a string, and a floating point number
    let tuple2 = (1, "fred", 3.1415)
    printfn "tuple1: %A    tuple2: %A" tuple1 tuple2

    // Tuple of single argument is the same as the argument
    let tuple3 = (1)

    // Tuple without any arguments (aka empty tuple) is a unit type
    let unit = ()

module BasicFunctions = 
    // Function that doesn't take any arg and returns 'void'
    let f () = ()

    // Use 'let' to define a function that accepts an integer argument and returns an integer. Then do a float version
    let func1 x = x*x + 3
    let func1a x = x*x + 3.

    // Explain signatures  
    // int -> float -> bool -> unit
     
    // Parentheses vs lack of them    
    let funcWithTuple (x, y) = x + y
    let funcWithMultiArgs x y = x + y
    let r1 = funcWithTuple (1, 2)
    let r2 = funcWithMultiArgs 1 2

    // Type inference to most generic type - swap tuple
    let swapElems (a, b) = (b, a)       

    // When needed, annotate the type of a parameter name using '(argument:type)'
    let func2 (x:int) : int = 2*x*x - x/5 + 3

    // Partial application (add10)
    let add x y = x + y
    let add10 = add 10

    printfn "%d" (add 3 4)
    printfn "%d" (add10 3)


module BoolsAndEquality = 
    // = and <>
    let x = true
    let y = false
    let z = x && y = x || y
    let u = z <> z


module StringsAndIdentifiers = 
    // Normal string
    let string1 = "Hello blabla"

    // Use @ to create a verbatim string literal
    let string3 = @"c:\Program Files\"

    // Using a triple-quote string literal
    let string4 = """He said "hello world" after you did"""

    // Using double backtick
    let ``A very long name of our unit test is perfectly accepltable`` = "something"

    let x = ``A very long name of our unit test is perfectly accepltable``
    

module Lists = 
    // empty list
    let list1 = []

    // list of a few elements
    let list2 = [ 1; 2; 3 ]

    // adding element to a list (cons cell)
    let list3 = 42::list2

    // range in list
    let numberList = [ 1 .. 1000 ]

    // Creating list using yield
    let blackSquares = 
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do 
                  if (i+j) % 2 = 1 then 
                      yield (i, j) ]

    // LINQ - map to squared numbers, piping, lambdas (fun)
    let squares = 
        numberList 
        |> List.map (fun x -> x*x) 

    // LINQ - filter, sumBy  
    let sumOfSquares = 
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)


module Arrays = 

    /// The empty array
    let array1 = [||]

    // array with some strings
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    // range
    let array3 = [| 1 .. 1000 |]

    // modify an array element using the left arrow assignment operator
    array2.[1] <- "WORLD!"

    /// Calculates the sum of the lengths of the words that start with 'h'. Note using Array module instead of Lists
    let sumOfLengthsOfWords = 
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)



module Sequences = 
    // Sequences are evaluated on-demand and are re-evaluated each time they are iterated. 
    // An F# sequence is an instance of a System.Collections.Generic.IEnumerable<'T>,
    // so Seq functions can be applied to Lists and Arrays as well.

    /// The empty sequence
    let seq1 = Seq.empty

    // Seq with yield
    let ss = seq { yield 1; yield 2 }
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    // Seq with ..
    let numbersSeq = seq { 1 .. 1000 }

module ControlFlow =
    // If then else
    let x = if 1 > 0 then "a" else "b"
    // If without else
    let y = 
        if "a" = "b" then
            ()
    
    // Pattern matching on int
    let foo =
        match 123 with
        | 1 -> "Nope"
        | 2 -> "Huh"
        | 123 -> "Yay"
        | 145 -> "Wat"
        | _ -> ""

    // Pattern matching on tuple with guards
    let q = "asd"
    let w = 123
    let bar = 
        match q, w with
        | "a", 1 -> 0
        | "b", 3 -> 1
        | "b", x when x < 4 && x > 0 -> 2
        | "b", _ -> 3
        | _, _ -> -1

    // Pattern matching on types
    let input = box "asdf"
    let baz = 
        match input with
        | :? int as input -> printfn "%d" input
        | :? float as input -> printfn "%f" input
        | :? string as input -> printfn "%s" input
        | _ -> printfn "I give up. %s" <| input.GetType().ToString()

    // for loop
    for i in 1 .. 10 do
        printfn "%d" i

    // while loop
    while (true) do
        printfn "Noooo..."

module RecursiveFunctions  = 
              
    /// Compute the factorial of an integer. Use 'let rec' to define a recursive function
    // let rec factorial n = 
    //     if n = 0 then 
    //         1 
    //     else 
    //         n * factorial (n-1)

    /// Computes the sum of a list of integers using recursion.
    // let rec sumList list =
    //     match list with
    //     | [] -> 0
    //     | hd::tl -> hd + sumList tl

    /// Make the function tail recursive, using a helper function with a result accumulator
    // let sumListTail list =
    //     let rec loop current list =
    //         match list with
    //         | [] -> current
    //         | hd::tl -> loop (current+hd) tl
    //     loop 0 list
    ()

module CombiningFunctions =
    // |> vs >>
    let add10 x = x + 10
    let multiplyby2 x = x * 2

    let addThenMultiply x = 
        add10 x |> multiplyby2
    
    let addThenMultiplyPointfree = add10 >> multiplyby2

// ---------------------------------------------------------------
//         EXERCISES
// ---------------------------------------------------------------

module Evercises =
    // write a function calculating BMI (kudos if it is outputing the category)
    // https://en.wikipedia.org/wiki/Body_mass_index#Categories


    // write FizzBuzz


    // reverse a string


    // count sum of squares of first 156 even positive integers


    // write function that outputs n-th element of a Fibonacci sequence


    // make factorial recursive func tail-recursive


    // write a function that counts all acurrences of all letters in a string. You can use Map or System.Collections.Generic.Dictionary to keep track of them

