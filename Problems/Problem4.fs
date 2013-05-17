module Problem4
    let Run =
        let rec getDigits x =
            if x < 10 then
                x :: []
            else
                let digit = x % 10
                let nextValue = x / 10
                (getDigits nextValue) @ [digit]

        let isPalindrome x =
            let rev = x |> List.rev
            x = rev

        let start = 100
        let max = 999
        let valueList = [start..max]

        valueList
        |> List.collect (fun x -> valueList |> List.map (fun y -> x * y))
        |> Seq.distinct
        |> Seq.toList
        |> List.filter (fun x -> isPalindrome (getDigits x))
        |> List.max