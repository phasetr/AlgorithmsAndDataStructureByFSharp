// https://atcoder.jp/contests/abc138/submissions/34157793
open System
open System.Collections.Generic

let read t =
    stdin.ReadLine() |> t

let readA t =
    stdin.ReadLine().Split() |> Array.map t

let inline (+=) (l: byref<_>) r = l <- l + r

let solve () =
    let [|N; Q|] = readA int
    let mutable neighbors = [| for _ in 1..N -> [] |]
    for _ in 1..N-1 do
        let [|a; b|] = readA int
        neighbors.[a-1] <- b-1 :: neighbors.[a-1]
        neighbors.[b-1] <- a-1 :: neighbors.[b-1]
    let mutable counts: int[] = Array.zeroCreate N
    for _ in 1..Q do
        let [|p; x|] = readA int
        &counts.[p-1] += x
    let rec dfs from v =
        &counts.[v] += counts.[from]
        neighbors.[v] |> List.filter ((<>) from) |> List.iter (dfs v)
    neighbors.[0] |> List.iter (dfs 0)
    counts |> Array.toSeq |> Seq.map string |> String.concat " "

solve() |> Console.WriteLine
