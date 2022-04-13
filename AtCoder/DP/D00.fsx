@"https://atcoder.jp/contests/dp/tasks/dp_d
N 個の品物があります。
品物には 1, 2, \ldots, N と番号が振られています。
各 i (1 \leq i \leq N) について、
品物 i の重さは w_i で、価値は v_i です。

太郎君は、N 個の品物のうちいくつかを選び、
ナップサックに入れて持ち帰ることにしました。
ナップサックの容量は W であり、
持ち帰る品物の重さの総和は W 以下でなければなりません。

太郎君が持ち帰る品物の価値の総和の最大値を求めてください。

制約

* 入力はすべて整数である。
* 1 \leq N \leq 100
* 1 \leq W \leq 10^5
* 1 \leq w_i \leq W
* 1 \leq v_i \leq 10^9"
#r "nuget: FsUnit"
open FsUnit

let N,W,wva = 3,8,[|(3,30L);(4,50L);(5,60L)|]
let solve N W (wva: array<int*int64>) = 1L
let N, W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let wva = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int x.[0], int64 x.[1]) |]
solve1 N W wva |> stdout.WriteLine

solve 3 8 [|(3,30L);(4,50L);(5,60L)|] |> should equal 90L
solve 5 5 [|(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L)|] |> should equal 5000000000L
solve 6 15 [|(6,5L);(5,6L);(6,4L);(6,6L);(3,5L);(7,2L)|] |> should equal 17L
