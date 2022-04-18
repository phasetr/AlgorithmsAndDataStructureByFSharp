@"https://atcoder.jp/contests/dp/tasks/dp_e
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
* 1 \leq W \leq 10^9
* 1 \leq w_i \leq W
* 1 \leq v_i \leq 10^3"
#r "nuget: FsUnit"
open FsUnit

let N,W,wva = 3,8L,[|(3L,30);(4L,50);(5L,60)|]
let solve N W wva =
    let f (dp:int64[]) (wi,vi) = [|0..100_000|] |> Array.map (fun v -> if v<vi then min dp.[v] wi else min (dp.[v-vi]+wi) dp.[v])
    Array.fold f (Array.replicate 100_001 1_000_000_001L) wva |> Array.takeWhile ((>=) W) |> Array.length
let N,W = stdin.ReadLine().Split() |> (fun x -> int x.[0], int64 x.[1])
let wva = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int64 x.[0], int x.[1]) |]
solve N W wva |> stdout.WriteLine

solve 3 8L [|(3L,30);(4L,50);(5L,60)|] |> should equal 90
solve 1 1000000000L [|(1000000000L,10)|] |> should equal 10
solve 6 15L [|(6L,5);(5L,6);(6L,4);(6L,6);(3L,5);(7L,2)|] |> should equal 17
