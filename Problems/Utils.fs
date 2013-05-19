module Utils
    let allPrimes max =
        let cache = new ResizeArray<int>()
        cache.Add(2)

        let rec isPrime num index = 
            match index with
            | _ when index >= cache.Count
                -> cache.Add(num); 
                    true
            | _ ->  let knownPrime = cache.[index]
                    match knownPrime with
                    | _ when num % knownPrime = 0 -> false
                    | _ -> isPrime num (index + 1)

        seq {
            yield 2L
            for x in 3..2..System.Int32.MaxValue do
                if isPrime x 0 then
                    yield x |> int64
            }
        |> Seq.takeWhile (fun x -> x <= max)

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