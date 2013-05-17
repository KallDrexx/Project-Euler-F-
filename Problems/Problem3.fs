module Problem3
    let Run =
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

