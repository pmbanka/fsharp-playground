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
