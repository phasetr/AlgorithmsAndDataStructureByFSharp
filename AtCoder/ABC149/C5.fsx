// https://atcoder.jp/contests/abc149/submissions/17004970
let readInt _ = stdin.ReadLine() |> int

let isPrime n =
    if n = 1L then
        true
    else
        seq { 2L .. n }
        |> Seq.filter (fun a -> a * a <= n)
        |> Seq.exists (fun x -> n % x = 0L)
        |> not

()
|> readInt
|> fun x ->
    Seq.initInfinite int64
    |> Seq.skip x
    |> Seq.filter isPrime
    |> Seq.head
    |> printfn "%d"
