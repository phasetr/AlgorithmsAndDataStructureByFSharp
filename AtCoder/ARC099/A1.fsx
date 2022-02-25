@"https://atcoder.jp/contests/arc099/tasks/arc099_a
2 \leq K \leq N \leq 100000
A_1, A_2, ..., A_N は 1, 2, ..., N の並び替え"
#r "nuget: FsUnit"
open FsUnit

@"まず1を見つけ, 1を前後に分配していく.
iより前の数・iより後ろの数をKで割れば求める結果が得られる.
変なコーナーケースはないか?
先頭が1の場合・最後に1が来ている場合もあり,
前後のどちらかが存在しない可能性はある.

1回の操作で(K-1)個ずつ1に変えられる前提で計算すればよい."
let N,K,As = 4,3,[|2;3;1;4|]
let N,K,As = 8,3,[|7;3;1;8;4;6;2;5|]
let solve N K As =
    if (N-1)%(K-1)=0 then (N-1)/(K-1) else (N-1)/(K-1) + 1
let N, K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let As = stdin.ReadLine().Split() |> Array.map int
solve N K As |> stdout.WriteLine

solve 4 3 [|2;3;1;4|] |> should equal 2
solve 3 3 [|1;2;3|] |> should equal 1
solve 8 3 [|7;3;1;8;4;6;2;5|] |> should equal 4
solve 11 3 [|10;9;7;1;3;8;4;6;2;5;11|] |> should equal 6
