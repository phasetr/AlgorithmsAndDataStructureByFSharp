@"https://atcoder.jp/contests/abc143/tasks/abc143_d
* 入力は全て整数
* 3 ≤ N ≤ 2 \times 10^3
* 1 \leq L_i \leq 10^3"
#r "nuget: FsUnit"
open FsUnit

@"解説から.
同じ長さを持つ棒が複数存在する場合,
予め適当に大小関係を決めた上で
1番目と2番目に長い三角形を構成する棒を固定する.
3番目に長い棒として使える棒は「2番目の棒より短く,
一定以上の長さを持つ棒」で,
この棒の数は予め棒の長さをソートしておけば二分探索で求められる.
1番目に長い棒と2番目に長い棒の選び方で探せば時間計算量
O(N^2 \log N)でわかる."
let solve N (La:array<int>) =
    let rec f a xa ya m n =
        if Array.isEmpty xa then 0
        elif Array.isEmpty ya then 0
        else
            let x = Array.head xa
            let y = Array.head ya
            if a+x>y then n - m + f a xa (Array.tail ya) m (n+1)
            elif m+1=n then f a xa (Array.tail ya) m (n+1)
            else f a (Array.tail xa) ya (m+1) n
    let rec g la =
        if Array.length la <= 2 then 0
        else
            let a = Array.head la
            let xa = Array.tail la
            f a xa la.[2..] 0 1 + g xa
    La |> Array.sort |> g
let N = stdin.ReadLine() |> int
let La = stdin.ReadLine().Split() |> Array.map int
solve N La |> stdout.WriteLine

solve 4 [|3;4;2;1|] |> should equal 1
solve 3 [|1;1000;1|] |> should equal 0
solve 7 [|218;786;704;233;645;728;389|] |> should equal 23
