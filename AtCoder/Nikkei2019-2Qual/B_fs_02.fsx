// https://atcoder.jp/contests/nikkei2019-2-qual/submissions/21631623
open System
let R = Console.ReadLine
let n = (R >> int)()
let d = R().Split() |> Array.map int64

[<Literal>]
let MOD = 998244353L
let modPow mod' x n =
    let rec f acc x n =
        if n > 0 then
            match n % 2 with
            | 0 -> f acc ((x * x) % mod') (n >>> 1)
            | _ -> f ((acc * x) % mod') ((x * x) % mod') (n >>> 1)
        else acc
    f 1L x n
let depthCounts =
    d
    |> Array.groupBy id
    |> Array.map (fun (depth, values) -> depth, values |> Array.length |> int)
    |> Array.sortBy fst
let isValid =
    d.[0] = 0L
    && depthCounts.Length > 1
    && depthCounts
    |> Array.map fst
    |> Array.pairwise
    |> Array.forall (fun (f, s) -> s - f = 1L)
    && depthCounts.[0] = (0L, 1)

if not isValid then
    0L
else
    let counts =
        depthCounts
        |> Array.map snd
        |> Array.toList
    let rec f (acc: int64) (parentNum: int64) : int list -> int64 = function
        | [] -> acc
        | x::xs -> f ((acc * (modPow MOD parentNum x)) % MOD) (int64 x) xs
    f 1L 1L counts
|> printfn "%d"
