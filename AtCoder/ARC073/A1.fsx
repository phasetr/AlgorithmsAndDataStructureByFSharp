@"https://atcoder.jp/contests/arc073/tasks/arc073_a
* 1 ≦ N ≦ 200,000
* 1 ≦ T ≦ 10^9
* 0 = t_1 < t_2 < t_3 < , ..., < t_{N-1} < t_N ≦ 10^9
* T, t_i はすべて整数である"
#r "nuget: FsUnit"
open FsUnit

@"int64で計算するべき.
残り時間を比較しながらfoldまたは再帰で計算すればよいだろう.

`i`人目がスイッチを押した後の挙動は次の人が
`T`秒以内に来るならお湯は出続け,
`T`秒より経ってから来るならお湯はT秒間出て止まる.
したがって`min T (次の人が来るまでの時間)`を計算すればよい."
let solve: int64 -> int64 -> array<int64> -> int64 = fun N T Ts ->
    Ts |> Array.pairwise
    |> Array.sumBy (fun (p,c) -> min T (c-p))
    |> (+) T
let N, T = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
let Ts = stdin.ReadLine().Split() |> Array.map int64
solve N T Ts |> stdout.WriteLine

solve 2L 4L [|0L;3L|] |> should equal 7L
solve 2L 4L [|0L;5L|] |> should equal 8L
solve 4L 1000000000L [|0L;1000L;1000000L;1000000000L|] |> should equal 2000000000L
solve 1L 1L [|0L|] |> should equal 1L
solve 9L 10L [|0L;3L;5L;7L;100L;110L;200L;300L;311L|] |> should equal 67L
