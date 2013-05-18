﻿namespace Problems1To10

module Problem1 =
    let Run() = 
        //If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        //Find the sum of all the multiples of 3 or 5 below 1000.
        [1..999]
        |> List.filter (fun x -> x % 3 = 0 || x % 5 = 0)
        |> List.sum

module Problem2 =
    let Run() =
        // Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
        // 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        // By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.

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

module Problem3 =
    let Run() =
        // The prime factors of 13195 are 5, 7, 13 and 29.
        // What is the largest prime factor of the number 600851475143 ?
        let number = 600851475143L

        Utils.allPrimes [] 2L (float number |> sqrt |> int64)
        |> List.filter (fun x -> number % x = 0L)
        |> List.max

module Problem4 =
    let Run() =
        // A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 99.
        // Find the largest palindrome made from the product of two 3-digit numbers.
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

module Problem5 =
    let Run() =
        // 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
        // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
        let values = [2..20]
        let primes = Utils.allPrimes [] 2L (values |> List.max |> int64)
        let primeAccumulator = primes |> List.map (fun x -> (x, 0))
                    
        let getPrimeCount primeFactors =
            let folder acc foundPrime = 
                let countPrimes tpl =
                    let prime, count = tpl
                    if foundPrime = prime then
                        prime, count + 1
                    else
                        prime, count

                acc |> List.map countPrimes

            primeFactors |> List.fold folder primeAccumulator

        let foldToMaxOccurances acc primeTuple =
            let setIfGreater accTuple =
                let accPrime, accCount = accTuple
                let prime, count = primeTuple
                if prime = accPrime && count > accCount then
                    prime, count
                else
                    accPrime, accCount

            acc |> List.map setIfGreater

        let getLeastCommonMultiple current primeCount = 
            let prime, count = primeCount
            current * ((float prime ** float count) |> int64)

        values
        |> List.map (fun x -> Utils.GetFactors primes (x |> int64)) // Get the prime factorization for each value
        |> List.map getPrimeCount  // Fold each factorization into a list of how many times each prime is used
        |> List.concat // Concat into one big list of primes with occurances
        |> List.fold foldToMaxOccurances primeAccumulator // Find the max occurance for each prime
        |> List.fold getLeastCommonMultiple 1L // Multiply all primes to the power of their occurance together