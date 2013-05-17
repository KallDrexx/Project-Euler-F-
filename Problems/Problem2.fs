module Problem2 
    let Run =
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

