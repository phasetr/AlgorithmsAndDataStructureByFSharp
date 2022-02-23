@"https://atcoder.jp/contests/abc126/tasks/abc126_c
1 ≤ N ≤ 10^5
1 ≤ K ≤ 10^5
入力はすべて整数"
#r "nuget: FsUnit"
open FsUnit

@"サイコロの出目がiのときに得点がK以上になるには,
K <= i*(2^j)をみたすjの分だけサイコロで表が出る必要がある.
あとはi=1,2,...,Nに関する確率を足し上げる.

精度が出るようにできるところまで整数で計算して,
最後に割り算で浮動小数計算にした."
let solve N K =
    let log2 x = (log x) / (log 2.0)
    let k = log2 (float K) |> ceil |> int
    let expn i = [|0..k|] |> Array.maxBy (fun j -> K <= i * pown 2 j)

    [|1..N|] |> Array.map (fun i -> N * (pown 2 (expn i)))
    |> Array.sumBy (fun x -> 1.0 / (float x))

let N, K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
solve N K |> stdout.WriteLine

solve 3 10 |> should equal 0.145833333333
solve 100000 5 |> should equal 0.999973749998
