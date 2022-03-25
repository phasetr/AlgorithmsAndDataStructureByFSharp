@"https://atcoder.jp/contests/abc143/tasks/abc143_d
* 入力は全て整数
* 3 ≤ N ≤ 2 \times 10^3
* 1 \leq L_i \leq 10^3"
#r "nuget: FsUnit"
open FsUnit

@"以下TLE.
全件探索しているので通らない."
let solve N (La:array<int>) =
    let check i j k =
        let a,b,c = La.[i],La.[j],La.[k]
        a<b+c && b<c+a && c<b+a
    [| for i in 0..(N-3) do
        for j in (i+1)..(N-2) do
        for k in (j+1)..(N-1) do
         if check i j k then Some (La.[i],La.[j],La.[k]) else None
    |] |> Array.choose id |> Array.length
let N = stdin.ReadLine() |> int
let La = stdin.ReadLine().Split() |> Array.map int
solve N La |> stdout.WriteLine

solve 4 [|3;4;2;1|] |> should equal 1
solve 3 [|1;1000;1|] |> should equal 0
solve 7 [|218;786;704;233;645;728;389|] |> should equal 23
