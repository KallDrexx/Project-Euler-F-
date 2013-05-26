module Utils
    let allPrimes max =
        let cache = new ResizeArray<int>()
        cache.Add(2)

        let (|IndexOutOfPrimes|) index = index >= cache.Count

        let rec isPrime num index = 
            match index with
            | IndexOutOfPrimes true
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

    let rec GetPrimeFactors allPrimes value =
        if value <= 1L then
            []
        else
            let divisiblePrime = allPrimes |> List.tryPick (fun x -> if value % x = 0L then Some(x) else None)
            match divisiblePrime with
            | None -> []
            | _    -> (Option.get divisiblePrime) :: (GetPrimeFactors allPrimes (value / (Option.get divisiblePrime)))

    let GetAllFactors number =
        let numbersToTest = [1..(float number |> sqrt |> int)]
        let rec factorize remainingTests knownFactors =
            match remainingTests with
            | [] -> knownFactors
            | _ 
                 -> let testValue = List.head remainingTests
                    if number % testValue = 0 then
                        factorize (List.tail remainingTests) (testValue :: (number / testValue) :: knownFactors)
                    else
                        factorize (List.tail remainingTests) knownFactors

        factorize numbersToTest [] 
        |> List.toSeq
        |> Seq.distinct
        |> Seq.sort
        |> Seq.toList
