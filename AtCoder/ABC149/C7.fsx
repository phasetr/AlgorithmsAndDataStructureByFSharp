// https://atcoder.jp/contests/abc149/submissions/9244890
let isPrime n =
    if n < 2 then
        false
    elif n = 2 then
        true
    else
        let r = n |> float |> sqrt |> ceil |> int

        [ for i in 2 .. r -> n % i = 0 ]
        |> List.contains true
        |> not

let rec loop n = if isPrime n then n else loop (n + 1)
stdin.ReadLine() |> int |> loop |> printfn "%d"
