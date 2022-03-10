@"https://atcoder.jp/contests/agc011/tasks/agc011_a
2 \leq N \leq 100000
1 \leq C \leq 10^9
1 \leq K \leq 10^9
1 \leq T_i \leq 10^9
C, K, T_i は整数"
#r "nuget: FsUnit"
open FsUnit

@"まずソートする.
時間Kの間にいる乗客をできるだけまとめて前からさばく.
バスが変わるのは出発時刻結果・定員超過.
条件分岐での不等号の処理に注意すること."
let N,C,K,Ta = 5,3,5,[|1;2;3;6;12|]
let N,C,K,Ta = 6,3,3,[|7;6;2;8;10;6|]
let solve N C K Ta =
    let ta = Ta |> Array.sort
    ta.[1..] |> Array.fold (fun (bus,pssg,time) t ->
        if time+K < t || C = pssg then (bus+1,1,t)
        else (bus,pssg+1,time)) (1,1,ta.[0])
    |> fun (bus,_,_) -> bus

let N,C,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
let Ta = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve N C K Ta |> stdout.WriteLine

solve 5 3 5 [|1;2;3;6;12|] |> should equal 3
solve 6 3 3 [|7;6;2;8;10;6|] |> should equal 3
