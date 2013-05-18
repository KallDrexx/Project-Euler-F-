open System
open System.Diagnostics
open System.Collections.Generic


[<EntryPoint>]
let main argv = 
    let sw = Stopwatch.StartNew()
    
    let solution = Problems1To10.Problem5.Run()
    printfn "%A" solution

    sw.Stop()
    printfn "Problem took %d minutes, %d seconds, and %d milliseconds" sw.Elapsed.Minutes sw.Elapsed.Seconds sw.Elapsed.Milliseconds
   
    0 // return an integer exit code
