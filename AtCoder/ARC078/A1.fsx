@"https://atcoder.jp/contests/abc067/tasks/arc078_a"
#r "nuget: FsUnit
- 2 \leq N \leq 2 \times 10^5
- -10^{9} \leq a_i \leq 10^{9}
- a_i は整数"
open FsUnit

@"N <= 10^5 だからある程度乱暴でもどうにかなるはず.
すぬけ・アライグマともにカードを持つことに注意が必要.
総和をS, i項目までの総和をxiとして
S-2*xiの最小値を取ればよい."
let solve N (Aa:array<int64>) =
    let sum = Array.sum Aa
    ((System.Int64.MaxValue, 0L), Aa.[0..N-2])
    ||> Array.fold (fun (s,x) ai ->
        let xi = x+ai
        (min s (abs (sum-2L*xi)), xi))
    |> fst
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 6 [|1L;2L;3L;4L;5L;6L|] |> should equal 1L
solve 2 [|10L;-10L|] |> should equal 20L
