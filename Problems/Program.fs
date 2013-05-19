open System
open System.Diagnostics
open System.Collections.Generic


[<EntryPoint>]
let main argv = 
    let sw = Stopwatch.StartNew()
    
    let solution = Problems1To10.Problem3.Run()
    sw.Stop()

    printfn "%A" solution
    printfn "Problem took %d minutes, %d seconds, and %d milliseconds" sw.Elapsed.Minutes sw.Elapsed.Seconds sw.Elapsed.Milliseconds
   
    0 // return an integer exit code
