@"https://atcoder.jp/contests/abc078/tasks/arc085_a
- 入力は全て整数
- 1 \leq N \leq 100
- 1 \leq M \leq {\rm min}(N, 5)"
#r "nuget: FsUnit"
open FsUnit

@"全てのケースで正解する確率は p=1/2^M で,
一回の実行にかかる時間は x=1900*M+100*(N-M).
総計をyとすると y = x + (1-p)*y だから整理すれば y = x/p で,
これに先の x を代入すればよい.
"
let solve N M = (M*1900 + 100*(N-M)) * (pown 2 M)
let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
solve N M |> stdout.WriteLine

solve 1 1 |> should equal 3800
solve 10 2 |> should equal 18400
solve 100 5 |> should equal 608000
