@"https://atcoder.jp/contests/abc152/tasks/abc152_c
問題文
1,…,N の順列 P1,…,PNが与えられます。
次の条件を満たす整数 i(1≤i≤N) の個数を数えてください。

任意の整数 j(1≤j≤i) に対して、 Pi≤Pj

制約
1≤N≤2×10^5
P1,…,PNは 1,…,N の順列である。
入力はすべて整数である。"
#r "nuget: FsUnit"
open FsUnit

/// 対象のP_iがそこまでの最小値か判定する
let comp (min, count) p =
    if p <= min then (p, count+1)
    else (min, count)
let solve N Ps =
    Ps
    |> Array.fold comp (System.Int32.MaxValue, 0)
    |> snd

let N = stdin.ReadLine() |> int
let Ps = stdin.ReadLine().Split() |> Array.map int
solve N Ps |> printfn "%d"

solve 5 [|4; 2; 5; 1; 3|] |> should equal 3
solve 4 [|4; 3; 2; 1|] |> should equal 4
solve 6 [|1; 2; 3; 4; 5; 6|] |> should equal 1
solve 8 [|5; 7; 4; 2; 6; 8; 1; 3|] |> should equal 4
solve 1 [|1|] |> should equal 1
