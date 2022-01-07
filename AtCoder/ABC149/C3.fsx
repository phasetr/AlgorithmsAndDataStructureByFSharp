#r "nuget: FsUnit"
open FsUnit

// https://atcoder.jp/contests/abc149/submissions/18539714
module PrimeNumbers =
    // isPrime - O(N)
    let isPrime num =
        let rec isPrimeR x i =
            match i, x % i with
            | i, _ when i >= x -> true
            | _, 0 -> false
            | i, _ -> isPrimeR x (i + 1)

        isPrimeR num 2

let x = stdin.ReadLine() |> int

Seq.initInfinite (fun i -> x + i)
|> Seq.find PrimeNumbers.isPrime
|> stdout.WriteLine
