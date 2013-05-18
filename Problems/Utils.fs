module Utils
    let rec allPrimes foundPrimes current max =
        if current >= max then
            foundPrimes
        else
            let nextValue = current + 1L

            if List.exists (fun x -> current % x = 0L) foundPrimes then
                allPrimes foundPrimes nextValue max
            else
                allPrimes (foundPrimes @ [current]) nextValue max  

    let rec GetFactors allPrimes value =
        if value <= 1L then
            []
        else
            let divisiblePrime = 
                allPrimes |> List.tryPick (fun x -> if value % x = 0L then Some(x) else None)

            if divisiblePrime = None then
                []
            else
                let nextValue = value / (Option.get divisiblePrime)
                (Option.get divisiblePrime) :: (GetFactors allPrimes nextValue)