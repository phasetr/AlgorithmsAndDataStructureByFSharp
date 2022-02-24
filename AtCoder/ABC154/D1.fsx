@"https://atcoder.jp/contests/abc154/tasks/abc154_d
1 ≤ K ≤ N ≤ 200000
1 ≤ p_i ≤ 1000
入力で与えられる値は全て整数"
#r "nuget: FsUnit"
open FsUnit

@"公式利用で和・期待値を求める.
精度の問題があるから小数にするのはぎりぎりまで遅らせる.
結果的に`(n*(n+1)/2)/n = (n+1)/2`が出てきて,
この`/2`は最後に取る.
参考: https://atcoder.jp/contests/abc154/submissions/25832467"
let solve N K (pa: array<int>) =
    let sums = pa |> Array.map (fun n -> n+1) |> Array.scan (+) 0
    Seq.map2 (-) (Array.skip K sums) sums |> Seq.max
    |> fun x -> (float x) / 2.0

let N, K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let pa = stdin.ReadLine().Split() |> Array.map int
solve N K pa |> stdout.WriteLine

solve 5 3 [|1;2;2;4;5|] |> should equal 7.000000000000
solve 4 1 [|6;6;6;6|] |> should equal 3.500000000000
solve 10 4 [|17;13;13;12;15;20;10;13;17;11|] |> should equal 32.000000000000
