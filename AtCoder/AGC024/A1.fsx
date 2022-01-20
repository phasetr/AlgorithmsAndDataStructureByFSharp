@"https://atcoder.jp/contests/agc024/tasks/agc024_a
問題文
高橋君、中橋君、低橋君は、それぞれ整数 A,B,C を持っています。
以下の操作を K 回行った後、
高橋君の持っている整数から中橋君の持っている整数を引いた値を求めてください。

3 人は同時に、他の 2 人の持っている整数の和を求める。
その後、自分の持っている整数を求めた整数で置き換える。
ただし、答えの絶対値が 10^{18}を超える場合は、
代わりに Unfair と出力してください。

制約
1≤A,B,C≤10^9
0≤K≤10^{18}
入力はすべて整数である"
#r "nuget: FsUnit"
open FsUnit

@"解説から
求めるべき数をxとして三人の整数が (A + x, A, B) だとする.
一回の操作後に三人はそれぞれ (A + B, A + B + x, 2A + x) を持ち,
求める値は x から −x に変わる."
let rec solve A B C K = if K%2L = 0L then A-B else B-A
let A,B,C,K = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1], x.[2], x.[3])
solve A B C K
|> fun s -> if abs s < 1000000000000000000L then printfn "%d" s else printfn "unfair"

solve 1L 2L 3L 1L |> should equal 1L
solve 2L 3L 2L 0L |> should equal -1L
solve 1000000000L 1000000000L 1000000000L 1000000000000000000L |> should equal 0L
