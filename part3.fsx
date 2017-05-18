#r @"packages/FSharpx.Extras/lib/net45/FSharpx.Extras.dll"

open System

module AsyncComputations =
    let sleep100 () = async { do! Async.Sleep 100 }
    let returnWithSleep () = 
        async {
            do! Async.Sleep 100
            return "Done"
        }
    let combined () =
        async {
            do! sleep100 ()
            let! result = returnWithSleep ()
            return "Done! " + result
        }
    let x = combined () |> Async.RunSynchronously

module MaybeComputations =
    open FSharpx.Option

    let x = maybe {
        let! x = Some 10
        let! y = Some 20
        let! z = None
        return x + y / z
    }

module SeqComputations = 
    let s1 () = seq {
        yield 1
        yield 2
    }

    let s2 () = seq {
        yield 3
        yield 4
    }

    let combined () = seq {
        yield! s1 ()
        yield! s2 ()
    }

    let result = combined ()

