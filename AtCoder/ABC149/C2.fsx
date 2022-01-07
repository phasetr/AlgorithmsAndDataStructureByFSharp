#r "nuget: FsUnit"
open FsUnit

let isPrime n =
    let intSqrt = (float >> sqrt >> int) n // square root of integer

    [| 2 .. intSqrt |] // all numbers from 2 to intSqrt
    |> Array.forall (fun x -> n % x <> 0) // no divisors

let allPrimesLargerThanN n =
    let rec recAllPrimes m =
        seq {
            if (isPrime m && n <= m) then yield m
            yield! recAllPrimes (m + 1) // recursing
        }

    recAllPrimes 1 // starting from 1

let solve2 n = allPrimesLargerThanN n |> Seq.head

stdin.ReadLine() |> int |> solve2 |> printfn "%d"

solve2 20 |> should equal 23
solve2 2 |> should equal 2
solve2 99992 |> should equal 100003
