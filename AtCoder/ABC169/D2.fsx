// https://atcoder.jp/contests/ABC169/submissions/13872716 そのまま
open System

let N = stdin.ReadLine() |> int64

let rec primes n a =
    if N < a * a then
        if n = 1L then [] else [ 1 ]
    elif n % a <> 0L then
        primes n (a + 1L)
    else
        let rec inner n acc =
            if n % a <> 0L then (n, acc) else inner (n / a) (acc + 1)

        let (n', c) = inner n 0
        c :: (primes n' (a + 1L))

let rec cnt n c =
    if n >= c then 1 + (cnt (n - c) (c + 1)) else 0

primes N 2L
|> List.fold (fun st x -> st + (cnt x 1)) 0
|> printfn "%d"
