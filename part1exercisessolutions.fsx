// ---------------------------------------------------------------
//         EXERCISES
// ---------------------------------------------------------------
open System
module Evercises =
    // write a function calculating BMI and outputing the category
    // https://en.wikipedia.org/wiki/Body_mass_index#Categories
    let bmi (mass:float) (height:float) = mass / (height * height) 

    // - write FizzBuzz

    let fizzbuzz n =
        if n % 15 = 0 then
            "fizbuzz"
        else if n % 5 = 0 then
            "buzz"
        else if n % 3 = 0 then
            "fizz"
        else
            n.ToString()

    [1 .. 15] |> Seq.map fizzbuzz |> List.ofSeq

    // reverse the string
    let reverse str =
        let rec loop s acc =
            if String.length s = 0 then
                acc
            else
                loop (s.[1 .. s.Length - 1]) (string (s.[0]) + acc)
        loop str ""

    reverse "abcde"

    // - count sum of squares of first 156 even positive integers
    let sum =
        [ 1 .. 156 ]
        |> Seq.where (fun x -> x % 2 = 0)
        |> Seq.map (fun x -> x*x)
        |> Seq.sum

    // - write function that outputs n-th element of a Fibonacci sequence
    let rec fibonacci n =
        match n with 
        | 0 -> 1
        | 1 -> 1
        | n -> fibonacci (n-1) + fibonacci (n-2)

    let fibonacciTailRec n = 
        let rec loop curr prev iteration =
            if iteration = n then
                curr
            else
                loop (curr + prev) curr (iteration+1)
        loop 1 1 2

    fibonacci 10

    // make factorial recursive func tail-recursive
    let factorial n =
        let rec loop curr n =
            if n = 0 then
                curr
            else
                loop (curr*n) (n-1)
        loop 1 n
    factorial 5

    // - write a function that counts all acurrences of all letters in a string. You can use Map or System.Collections.Generic.Dictionary to keep track of them
    let count input =
        let rec loop acc str =
            if str = "" then
                acc
            else
                let curr = str.[0]
                let remainig = str.[1 .. (str.Length-1)]
                let newMap = 
                    if Map.containsKey curr acc then
                        Map.add curr (acc.[curr] + 1) acc
                    else
                        Map.add curr 1 acc
                loop newMap remainig
        loop Map.empty input

    count "aabbc"

