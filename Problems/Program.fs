open System
open System.Diagnostics
open System.Collections.Generic

let problem1 = 
    [1..999]
    |> List.filter (fun x -> x % 3 = 0 || x % 5 = 0)
    |> List.sum

let problem2 =
    let maxValue = 4000000
    let rec fibNext a b = 
        if a + b < maxValue then
            let current = a + b
            current :: fibNext b current
        else
            []

    1 :: fibNext 1 1 
    |> List.filter (fun x -> x % 2 = 0)
    |> List.sum

let problem3 =
    let rec allPrimes foundPrimes current max =
        if current >= max then
            foundPrimes
        else
            let nextValue = current + 1L

            if List.exists (fun x -> current % x = 0L) foundPrimes then
                allPrimes foundPrimes nextValue max
            else
                allPrimes (foundPrimes @ [current]) nextValue max                                

    let number = 600851475143L

    allPrimes [] 2L (float number |> sqrt |> int64)
    |> List.filter (fun x -> number % x = 0L)
    |> List.max


[<EntryPoint>]
let main argv = 
    let sw = Stopwatch.StartNew()
    
    printfn "%A" problem3

    sw.Stop()
    printfn "Problem took %d minutes, %d seconds, and %d milliseconds" sw.Elapsed.Minutes, sw.Elapsed.Seconds, sw.Elapsed.Milliseconds
    
    let s = Console.ReadLine()
    0 // return an integer exit code
