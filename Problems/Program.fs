open System
open System.Diagnostics
open System.Collections.Generic

[<EntryPoint>]
let main argv = 
    let sw = Stopwatch.StartNew()
    
    printfn "%A" Problem3.Run

    sw.Stop()
    printfn "Problem took %d minutes, %d seconds, and %d milliseconds" sw.Elapsed.Minutes sw.Elapsed.Seconds sw.Elapsed.Milliseconds
    
    let s = Console.ReadLine()
    0 // return an integer exit code
